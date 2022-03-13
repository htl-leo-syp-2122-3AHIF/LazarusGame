using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
namespace BattleUIController
{
    public class BattleUI : MonoBehaviour
    {
        private Button attackButton;
        private Button itemButton;
        private ProgressBar healthBar;
        private Label playerName;
        private Label dialogueText;
        private VisualElement dialogueWindow;

        public Button AttackButton { get => attackButton; set => attackButton = value; }
        public Button ItemButton { get => itemButton; set => itemButton = value; }
        public ProgressBar HealthBar { get => healthBar;  }
        public Label PlayerName { get => playerName; }
        public Label DialogueText { get => dialogueText;}
        public VisualElement DialogueWindow { get => dialogueWindow; set => dialogueWindow = value; }

        // Start is called before the first frame update
        void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            AttackButton = root.Q<Button>("AttackBtn");
            ItemButton = root.Q<Button>("ItemBtn");
            healthBar = root.Q<ProgressBar>("HealthBar");
            playerName = root.Q<Label>("PlayerName");
            dialogueText = root.Q<Label>("Dialogue");
            DialogueWindow = root.Q<VisualElement>("DialogueWindow");
            
        }
        
        public void SetDialogue(string text)
        {
            DialogueText.text += text;
        }
        public void ChangeHealthBarProgress(float value)
        {
            HealthBar.value = value;
        }
        public void SetPlayerName(string name)
        {
            PlayerName.text = $"Name: {name}";
        }

    }
}

