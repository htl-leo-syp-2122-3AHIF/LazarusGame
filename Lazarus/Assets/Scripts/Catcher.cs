using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    private bool _moveAllowed;
    [SerializeField]
    private BoxCollider2D _gridArea;
    [SerializeField]
    private float SPEED = 3;
    private float _points;

    public float Points { get => _points; set => _points = value; }

    // Start is called before the first frame update
    void Start()
    {
        _moveAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move("a");
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Move("d");
        }
    }

    private void Move(string v)
    {
        switch (v)
        {
            case "a":
                this.transform.Translate(Vector3.left * SPEED * Time.deltaTime);
                break;
            case "d":
                this.transform.Translate(Vector3.right * SPEED * Time.deltaTime);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftWallCatch")
        {
            _moveAllowed = false;
        } else if (collision.tag == "Fruit")
        {
            _points++;
        }
    }
}
