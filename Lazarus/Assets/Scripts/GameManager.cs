using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum States
{
    
    Player,
    Enemy
}
public class GameManager : MonoBehaviour
{
    private const string BATTLE_PATH = "/Saves/BattleSave.laz";

    private States _currState;
    private PlayerStats _playerStats;
    VisualElement _uiElements;
    private Button _attackButton;
    private Button _itemButton;
    private ProgressBar _healthBar;
    private Label _playerName;
    private Label _dialogeText;
    private VisualElement _dialogueWindow;

    public Button AttackButton { get => _attackButton; set => _attackButton = value; }
    public Button ItemButton { get => _itemButton; set => _itemButton = value; }
    public ProgressBar HealthBar { get => _healthBar; }
    public Label PlayerName { get => _playerName; }
    public Label DialogueText { get => _dialogeText; set => _dialogeText = value; }
    public VisualElement DialogueWindow { get => _dialogueWindow; set => _dialogueWindow = value; }
    
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = SaveLoadSystem.LoadGameData(BATTLE_PATH);
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

        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currState)
        {
            case States.Player:
                _currState = States.Enemy ;
                
                break;
            case States.Enemy:
                _currState = States.Player;
                break;
        }
    }
    public void Attack()
    {
        Debug.Log("AttackTest");

        
    }
    public void Items()
    {
        Debug.Log("ItemTest");
    }
    public void ChangeHealth(int value)
    {
        HealthBar.SetValueWithoutNotify(_playerStats.Health-value);
        _playerStats.Health=(int)HealthBar.value;
    }
}
