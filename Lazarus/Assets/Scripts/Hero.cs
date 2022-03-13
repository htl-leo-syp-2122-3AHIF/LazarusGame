using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private int SPEED =1000 ;
    [SerializeField]
    private float _encounterStartNum = 20F;

    private Animator _anim;
    private Vector3 _movement;
    
    private int _health;
    private int _strength;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if(value>0)
            {
                _health = value;
            }
            
        }
    }

    public int Strenght
    {
        get
        {
            return _strength;
        }
        set
        {
           if(value>0)
            {
                _strength = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _anim = GetComponent<Animator>();
        
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if (_movement != Vector3.zero)
        {
            Move();
        }
        

    }

    private void Move()
    {
        //change the values of the params in the animator
        _anim.SetFloat("changeX", _movement.x);
        _anim.SetFloat("changeY", _movement.y);
        if(-_movement!=Vector3.zero)
        {
            _anim.SetFloat("lookAtX", _movement.x);
            _anim.SetFloat("lookAtY", _movement.y);
        }

        //change playerpos to new position
        this.transform.Translate(_movement * SPEED * Time.deltaTime);

        //random battle encounter
        RandomBattle();
        

    }

    private void RandomBattle()
    {
        float random = Mathf.Round(UnityEngine.Random.Range(0F, 1000F));
        
        if (random == _encounterStartNum)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Battle");
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() ;
    }
}
