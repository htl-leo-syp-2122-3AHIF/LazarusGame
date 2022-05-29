using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private int SPEED =3 ;
    [SerializeField]
    private float ENCOUNTER_START_NUM = 20F;

    private Animator _anim;
    private Vector3 _movement;
    private PlayerStats _playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = Const.GetPlayerStatsFromPermanentSave();
        _anim = GetComponent<Animator>();
        _movement = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _anim.SetFloat("changeX", _movement.x);
        _anim.SetFloat("changeY", _movement.y);
        //change the values of the params in the animator
            
        if (_movement != Vector3.zero)
        {
            _anim.SetFloat("lookAtX", _movement.x);
            _anim.SetFloat("lookAtY", _movement.y);

            //random battle encounter
            RandomBattle();
        }

        //change playerpos to new position
        this.transform.Translate(_movement * SPEED * Time.deltaTime);
    }

    private void RandomBattle()
    {
        float random = Mathf.Round(UnityEngine.Random.Range(0F, 100F));
        
        if (random == ENCOUNTER_START_NUM)
        {
            SaveLoadSystem.SaveGame(_playerStats, Const.BATTLE_PATH);
            SceneManager.LoadScene("Battle");
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() ;
    }
}
