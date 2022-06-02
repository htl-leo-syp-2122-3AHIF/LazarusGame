using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private float _toX;
    [SerializeField]
    private float _toY;
    [SerializeField]
    private bool _isRight;
    [SerializeField]
    private float _resetX;
    [SerializeField]
    private float _resetY;

    public float ToY { get => _toY; set => _toY = value; }
    public float ToX { get => _toX; set => _toX = value; }
    public float ResetY { get => _resetY; set => _resetY = value; }
    public float ResetX { get => _resetX; set => _resetX = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsRight)
        {
            collision.gameObject.transform.position = new Vector3(ToX, ToY, collision.transform.position.z);
        }
        else
        {
            collision.gameObject.transform.position = new Vector3(ResetX, ResetY, collision.transform.position.z);
        }

    }


}
