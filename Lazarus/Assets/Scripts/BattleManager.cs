using System.Collections;
using System.Collections.Generic;
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
    private const string BATTLE_PATH = "/Saves/BattleSave.laz";
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


    public States CurrState { get => _currState; set => _currState = value; }
    public Button AttackButton { get => _attackButton; set => _attackButton = value; }
    public Button ItemButton { get => _itemButton; set => _itemButton = value; }
    public ProgressBar HealthBar { get => _healthBar; }
    public Label PlayerName { get => _playerName; }
    public Label DialogueText { get => _dialogeText; set => _dialogeText = value; }
    public VisualElement DialogueWindow { get => _dialogueWindow; set => _dialogueWindow = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        _playerStats = Const.GetPlayerStatsFromTempSave();
        
        _uiElements = UI.GetAllUIElements("BattleUI");
        _currState = States.Player;
        AttackButton = _uiElements.Q<Button>("AttackBtn");
        ItemButton = _uiElements.Q<Button>("ItemBtn");
        _healthBar = _uiElements.Q<ProgressBar>("HealthBar");
        _playerName = _uiElements.Q<Label>("PlayerName");
        DialogueText = _uiElements.Q<Label>("Dialogue");
        DialogueWindow = _uiElements.Q<VisualElement>("DialogueWindow");
        HealthBar.highValue = _playerStats.Health;
        HealthBar.lowValue = 0;
        HealthBar.SetValueWithoutNotify(_playerStats.Health);
        AttackButton.clicked+=Attack;
        ItemButton.clicked += Items;
        PlayerName.text = "Name: "+_playerStats.Name;
        _enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        Debug.Log(_playerStats.Health);
        ChangeHealth(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        float random = Mathf.Round(UnityEngine.Random.Range(0F, 10F));
        if(random==CRIT_DAMAGE_CHANCE)
        {
            _enemy.Health -= _playerStats.CritDamage;
            _dialogeText.text = "Enemy took " + _playerStats.CritDamage + " Damage!";
        }
        else
        {
            _enemy.Health -= _playerStats.AttackDamage;
            _dialogeText.text = "Enemy took " + _playerStats.AttackDamage + " Damage!";
        }
        if (_enemy.Health<=0)
        {
            SceneManager.LoadScene("World");

        }
        _currState = States.Enemy;

    }
    public void Items()
    {
        Debug.Log("ItemTest");
        _currState = States.Enemy;
    }

    public void ChangeHealth(float value)
    {
        HealthBar.SetValueWithoutNotify(_playerStats.Health-value);
        _playerStats.Health=HealthBar.value;
    }

    private void OnDestroy()
    {
        _playerStats.Health = HealthBar.value;
        SaveLoadSystem.SaveGame(_playerStats, Const.BATTLE_PATH);
    }

}
