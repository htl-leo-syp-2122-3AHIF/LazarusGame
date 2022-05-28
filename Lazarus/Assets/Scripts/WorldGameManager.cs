using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WorldGameManager : MonoBehaviour
{
    private VisualElement _rootElement;

    // Start is called before the first frame update
    void Start()
    {
        _rootElement = UI.GetAllUIElements("UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuInput(InputAction.CallbackContext context)
    {
        _rootElement = UI.GetAllUIElements("UI");
    }
}
