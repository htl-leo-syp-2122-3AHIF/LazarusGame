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
        VisualElement ui = UI.GetAllUIElements("GameOver");
        ui.Q<Button>("LoadButton").clicked+=LoadLastSave;
        ui.Q<Button>("ExitButton").clicked += Const.EndGame;
    }

    public void LoadLastSave()
    {
        File.Delete(Application.dataPath+ Const.BATTLE_PATH);
        SceneManager.LoadScene("World");
    }
}
