using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoneDodger : MonoBehaviour
{
    [SerializeField]
    private float SPEED = 10;
    private float _points;
    private Vector3 _movement;
    private Vector3 _restrictedMovement;

    public float Points { get => _points; set => _points = value; }

    void Start()
    {
        _movement = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (_movement != Vector3.zero || _movement == _restrictedMovement)
        { 
            Move();
        }
    }

    private void Move()
    {
        this.transform.Translate(_movement * SPEED * Time.deltaTime);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}
