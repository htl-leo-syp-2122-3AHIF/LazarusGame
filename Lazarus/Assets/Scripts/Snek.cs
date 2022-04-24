using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    [SerializeField]
    private float MOVE_DELAY = 0.5F;
    [SerializeField]
    private Transform segmentPrefab;

    private bool _notFirstCollision;
    private BattleManager _battleManager;
    private Vector2 _direction;
    private float _lastMove;
    private List<Transform> _segments;
    private float _points;

    private void Start()
    {
        _direction = Vector2.right;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        _battleManager = (BattleManager)GameObject.Find("GameManager").GetComponent("BattleManager");
        _notFirstCollision = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - _lastMove > MOVE_DELAY) // Move around every MOVE_DELAY second (Theoretically at the exact delay)
        {
            _lastMove = Time.time;
            Move();
        }
    }
    private void Move()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0F
        );
    }

    private void Grow()
    {
        Vector3 lastPos = _segments[_segments.Count - 1].position;
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = lastPos;
        _segments.Add(segment);
        
    }
    private void StopMinigame()
    {
        foreach (Transform segment in _segments)
        {
            Destroy(segment.gameObject);
        }
        _battleManager.CurrState = States.Player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Food")
        {
            Grow();
            _points++;
        } else if (collision.tag == "Wall" || collision.tag == "SnakeSegment" && _notFirstCollision)
        {
            StopMinigame();
        } else if (collision.tag == "SnakeSegment" && !_notFirstCollision)
        {
            _notFirstCollision = true;
        }
    }

    
}
