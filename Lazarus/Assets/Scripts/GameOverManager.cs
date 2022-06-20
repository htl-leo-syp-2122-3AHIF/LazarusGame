using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement ui = UI.GetAllUIElements("UI");
        ui.Q<Button>("LoadButton").clicked+=Const.EndGame;
        ui.Q<Button>("ExitButton").clicked += Const.EndGame;
    }

    public void LoadLastSave()
    {
        File.Delete(Path.Combine(Application.dataPath, Const.BATTLE_PATH));
        SceneManager.LoadScene("World");
    }
}
