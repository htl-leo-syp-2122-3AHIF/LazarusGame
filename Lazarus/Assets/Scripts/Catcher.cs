using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField]
    private float SPEED = 40;
    private float _points;
    private bool _moveLeftRestrict;
    private bool _moveRightRestrict;
    private BattleManager _battleManager;
    private float _startTime;
    [SerializeField]
    private float MAX_TIME = 10;

    public float Points { get => _points; set => _points = value; }

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _moveLeftRestrict = false;
        _moveRightRestrict = false;
        _battleManager = (BattleManager)GameObject.Find("GameManager").GetComponent("BattleManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - _startTime > MAX_TIME)
        {
            _battleManager.CurrState = States.Player;
        }

        if (Input.GetKey(KeyCode.A) && !_moveLeftRestrict)
        {
            _moveRightRestrict = false;
            Move("a");
        }
        else if (Input.GetKey(KeyCode.D) && !_moveRightRestrict)
        {
            _moveLeftRestrict = false;
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
        Debug.Log($"Collision with {collision.tag}");
        if (collision.tag == "Fruit")
        {
            _points++;
        }
        else if (collision.tag == "LeftWallCatch")
        {
            _moveLeftRestrict = true;
            transform.position = new(Mathf.RoundToInt(transform.position.x), transform.position.y, 0);
        }
        else if (collision.tag == "RightWallCatch") 
        {
            _moveRightRestrict = true; 
            transform.position = new(Mathf.RoundToInt(transform.position.x), transform.position.y, 0);
        }
    }
    private void OnDestroy()
    {
        Enemy enemy = _battleManager.Enemy;
        _battleManager.ChangeHealth(enemy.Damage);
    }
}
