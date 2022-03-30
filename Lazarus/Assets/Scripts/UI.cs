using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class UI
{
    public static VisualElement GetAllUIElements(string tagName)
    {
        return  GameObject.FindGameObjectWithTag(tagName).GetComponent<UIDocument>().rootVisualElement;
    }


    
}
