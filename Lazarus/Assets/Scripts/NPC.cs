using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    

    private TMP_Text _popUp;
    private TMP_Text _playerText;
    private Canvas _npcCanvas;
    private Canvas _playerCanvas;
    
    [SerializeField]
    private string _npcText;

    private void Start()
    {
        _popUp = gameObject.GetComponentInChildren<TMP_Text>(true);
        _npcCanvas = gameObject.GetComponentInChildren<Canvas>(true);
    }

    private void Update()
    {
        if (_npcCanvas.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerText != null && _playerCanvas != null)
            {
                _playerCanvas.gameObject.SetActive(true);
                _playerText.text = _npcText;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _npcCanvas.gameObject.SetActive(true);
            _playerText = collision.gameObject.GetComponentInChildren<TMP_Text>(true);
            _playerCanvas = collision.gameObject.GetComponentInChildren<Canvas>(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (_playerText != null && _playerCanvas != null)
            {
                _playerCanvas.gameObject.SetActive(false);
                _playerText.text = "";
            }
            _npcCanvas.gameObject.SetActive(false);
        }
    }
}
