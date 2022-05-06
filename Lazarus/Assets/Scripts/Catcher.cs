using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    private bool _moveAllowedLeft;
    private bool _moveAllowedRight;
    [SerializeField]
    private BoxCollider2D _gridArea;
    [SerializeField]
    private float SPEED = 3;
    private float _points;

    public float Points { get => _points; set => _points = value; }

    // Start is called before the first frame update
    void Start()
    {
        _moveAllowedLeft = true;
        _moveAllowedRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= -19 | transform.position.x <= 19)
        {
            if (Input.GetKey(KeyCode.A) && _moveAllowedLeft)
            {
                Move("a");
                _moveAllowedRight = true;
            }
            else if (Input.GetKey(KeyCode.D) && _moveAllowedRight)
            {
                Move("d");
                _moveAllowedLeft = true;
            }
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

        if (collision.tag == "Fruit")
        {
            _points++;
        }
    }
}
