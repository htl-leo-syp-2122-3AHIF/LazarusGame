using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to load")]
    public string _gameLevel;
    [SerializeField]
    private GameObject noSaveGameDialogue = null;


    public void NewGameDialogYes()
    {
        if (File.Exists(Const.SAVE_PATH))
        {
            File.Delete(Const.SAVE_PATH);
        }
        SceneManager.LoadScene(_gameLevel);
    }

    public void LoadGameDialogYes()
    {
        if(File.Exists(Const.SAVE_PATH))
        {
            SceneManager.LoadScene(_gameLevel);
        }
        else
        {
            noSaveGameDialogue.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
