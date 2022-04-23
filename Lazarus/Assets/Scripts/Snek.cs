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

    private Vector2 _direction;
    private float _lastMove;
    private List<Transform> _segments;
    private float _points;

    private void Start()
    {
        _direction = Vector2.right;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
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
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void StopMinigame()
    {
        // Points -> 
        Debug.Log("To do: JULIAN MACH DAS");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            _points++;
        } else if (collision.tag == "Obstacle")
        {
            StopMinigame();
        }
    }

    
}
