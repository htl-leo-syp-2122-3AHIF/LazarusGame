using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum States
{
    Player,
    Enemy
}
public class BattleManager : MonoBehaviour
{
    public const string DEF_TEXT = "What do you want to do?";
    private const int CRIT_DAMAGE_CHANCE = 5;

    private States _currState;
    private PlayerStats _playerStats;
    VisualElement _uiElements;
    private Button _attackButton;
    private Button _itemButton;
    private ProgressBar _healthBar;
    private Label _playerName;
    private Label _dialogeText;
    private VisualElement _dialogueWindow;
    private Enemy _enemy;
    private float _enemyDamage;
    private Inventory _inventory;
    private ScrollView _inventoryScroller;
    


    public States CurrState { get => _currState; set => _currState = value; }
    public Button AttackButton { get => _attackButton; set => _attackButton = value; }
    public Button ItemButton { get => _itemButton; set => _itemButton = value; }
    public ProgressBar HealthBar { get => _healthBar; }
    public Label PlayerName { get => _playerName; }
    public Label DialogueText { get => _dialogeText; set => _dialogeText = value; }
    public VisualElement DialogueWindow { get => _dialogueWindow; set => _dialogueWindow = value; }
    public float EnemyDamage { get => _enemyDamage; set => _enemyDamage = value; }
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    public ScrollView InventoryScroller { get => _inventoryScroller; set => _inventoryScroller = value; }

    


    // Start is called before the first frame update
    void Start()
    {
        _playerStats = Const.GetPlayerStatsFromTempSave(false);
        
        _uiElements = UI.GetAllUIElements("BattleUI");
        _currState = States.Player;
        AttackButton = _uiElements.Q<Button>("AttackBtn");
        ItemButton = _uiElements.Q<Button>("ItemBtn");
        _healthBar = _uiElements.Q<ProgressBar>("HealthBar");
        _playerName = _uiElements.Q<Label>("PlayerName");
        DialogueText = _uiElements.Q<Label>("Dialogue");
        DialogueWindow = _uiElements.Q<VisualElement>("DialogueWindow");
        InventoryScroller = _uiElements.Q<ScrollView>("Items");
        HealthBar.highValue = _playerStats.MaxHealth;
        HealthBar.lowValue = 0;
        HealthBar.value = _playerStats.Health;
        
        AttackButton.clicked+=Attack;
        ItemButton.clicked += Items;
        Enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        DialogueText.text = DEF_TEXT;
        EnemyDamage = 0;
        _playerName.text = _playerStats.Name;
        _inventory = _playerStats.Inventory;

        foreach (Item item in _inventory.Items.Keys)
        {
            Button btn = new Button();
            btn.text = "" + item.Name + ":" + _inventory.Items[item];
            InventoryScroller.Add(btn);
            btn.RegisterCallback<ClickEvent>(delegate {
                Item foundItem= _inventory.UseItem(item.Name,_playerStats);
                
                if (_inventory.Items[item] == 0)
                {
                    InventoryScroller.Remove(btn);
                    _inventory.Items.Remove(item);
                }
                else
                {
                    btn.text = "" + item.Name + ":" + _inventory.Items[item];
                }
                if(foundItem!=null)
                {
                    HealthBar.value= _playerStats.Health;
                    DialogueText.text = "Your " + item.Type.ToString() + " is now " + item.Amount + " points higher!";
                }
                else
                {
                    DialogueText.text = "You already have full health!";
                }
                Items();
            });
        }
        InventoryScroller.SetEnabled(false);
        InventoryScroller.visible = false;
    }

   

    public void Attack()
    {
        float random = Mathf.Round(UnityEngine.Random.Range(0F, 10F));
        if(random==CRIT_DAMAGE_CHANCE)
        {
            Enemy.Health -= _playerStats.CritDamage;
            _dialogeText.text = "Enemy took " + _playerStats.CritDamage + " Damage!";
        }
        else
        {
            Enemy.Health -= _playerStats.AttackDamage;
            _dialogeText.text = "Enemy took " + _playerStats.AttackDamage + " damage!";
            
        }
        if (Enemy.Health<=0)
        {
            SceneManager.LoadScene("World");
        }
        
        StartCoroutine(DelayForButtons());


    }
    public void Items()
    {

        if (_dialogeText.text==DEF_TEXT)
        {
            DialogueText.text = "";
            InventoryScroller.SetEnabled(true);
            InventoryScroller.visible = true;
            if (_inventory.Items.Count == 0)
            {
                InventoryScroller.SetEnabled(false);
                InventoryScroller.visible = false;
                DialogueText.text = "No Items Found!";
            }
            Debug.Log(_dialogeText.text);
        }
        else
        {
            
            StartCoroutine(DelayForButtons());

        }

    }

    public void ChangeHealth(float damage)
    {
        HealthBar.value -= damage;
        _playerStats.Health=HealthBar.value;
        _dialogeText.text = "You took " + damage + " damage!";
        if (_playerStats.Health <= 0)
        {
            _dialogeText.text = "You died!";
            SceneManager.LoadScene("GameOver");
        }
        StartCoroutine(DelayForEnemyAttack());

    }

    private void OnDestroy()
    {
        _playerStats.ResetStatsAfterBattle();
        SaveLoadSystem.SaveGame(_playerStats, Const.BATTLE_PATH);
    }
    IEnumerator DelayForButtons()
    {
        AttackButton.SetEnabled(false);
        ItemButton.SetEnabled(false);
        InventoryScroller.SetEnabled(false);
        InventoryScroller.visible = false;
        yield return new WaitForSeconds(2);
        _dialogeText.text = DEF_TEXT;
        _currState = States.Enemy;

    }
    IEnumerator DelayForEnemyAttack()
    {
        AttackButton.SetEnabled(false);
        ItemButton.SetEnabled(false);

        yield return new WaitForSeconds(2);
        _dialogeText.text = DEF_TEXT;
        _currState = States.Player;
        AttackButton.SetEnabled(true);
        ItemButton.SetEnabled(true);

    }
}
