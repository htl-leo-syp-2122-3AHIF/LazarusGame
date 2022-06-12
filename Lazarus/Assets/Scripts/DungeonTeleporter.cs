using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DungeonTeleporter : MonoBehaviour
{
    [SerializeField]
    private float _toX;
    [SerializeField]
    private float _toY;
    [SerializeField]
    private bool _isRight;
    [SerializeField]
    private string _message;
    private Animator _anim;


    public void Start()
    {
        
        _anim = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<Animator>();
    }

    public float ToY { get => _toY; set => _toY = value; }
    public float ToX { get => _toX; set => _toX = value; }
    public string Message { get => _message; set => _message = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Hero>().enabled = false;
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("BlackScreenText").GetComponent<TextMeshProUGUI>();
        text.text = _message;
        collision.GetComponent<Hero>().enabled = true;
        collision.gameObject.transform.position = new Vector3(ToX, ToY, collision.transform.position.z);
    }


}
