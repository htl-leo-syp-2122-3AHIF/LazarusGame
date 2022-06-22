using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _noSaveGameDialogue = null;
    [SerializeField]
    private TMP_InputField _inputField = null;

    private string _gameLevel;

    public void Start()
    {
        _gameLevel = "World";
    }

    public void NewGameDialogAccept()
    {
        if (File.Exists(Application.dataPath + Const.SAVE_PATH))
        {
            File.Delete(Application.dataPath + Const.SAVE_PATH);
            File.Delete(Application.dataPath + Const.SAVE_PATH + ".meta");
        }

        PlayerStats playerStats = new PlayerStats(_inputField.text);

        SaveLoadSystem.SaveGame(playerStats, Const.SAVE_PATH);
        
        SceneManager.LoadScene(_gameLevel);
    }

    public void LoadGameDialogYes()
    {
        if(File.Exists(Application.dataPath + Const.SAVE_PATH))
        {
            SceneManager.LoadScene(_gameLevel);
        }
        else
        {
            _noSaveGameDialogue.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
