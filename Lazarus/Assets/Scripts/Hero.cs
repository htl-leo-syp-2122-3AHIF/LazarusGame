using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private int SPEED = 2;
    
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
        _anim = GetComponent<Animator>();
        _movement = Vector3.zero;
    }



    private void Update()
    {
        _movement = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        if (_movement != Vector3.zero)// to safe it for the idle direction
        {

            //change the values of the params in the animator
            _anim.SetFloat("changeX", _movement.x);
            _anim.SetFloat("changeY", _movement.y);
        }
        this.transform.Translate(_movement * SPEED* Time.deltaTime);

    }
}
