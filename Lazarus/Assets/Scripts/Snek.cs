using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Snek : MonoBehaviour
{
    public VisualElement _uiWindow;

    // Start is called before the first frame update
    void Start()
    {
        _uiWindow = UI.GetAllUIElements("BattleUI").Q<VisualElement>("DialogueWindow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
