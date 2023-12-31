﻿using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro PRG/Character Movement
[AddComponentMenu("Game Sytems/Player Movement")]
//This script requires the component Character controller to be attached to the Game Object
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour 
{
    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/
    #endregion



    #region Variables
    //[Header("Character")]
    //vector3 called moveDir //we will use this to apply movement in worldspace
    //Character controller called _charC CharacterController.html) 

    [SerializeField] private CharacterController _characterController;

    //[Header("Character Speeds")]
    //public float variables jumpSpeed 8 & speed 5 & gravity 20 

    [Header("Direction and Physics"), Space(5)]
    [SerializeField] private Vector3 _moveDirection;


    [Header("Speeds"), Space(5),Tooltip("This is the move speed of the charachter"), SerializeField, Range(0,20)] private float _movespeed = 5; // Range(0,20) creates a slider in unity that caps how high you can set the unit (in this case between 0 and 20)
    [SerializeField] private float _jumpSpeed = 8, _speed = 5, _crouchSpeed = 2.5f, _sprintSpeed = 10, _gravity = 20;



    #endregion


    #region Start  
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    #endregion



    #region Update

    private void Update()
    {

        if (true)//only move if we should move (are we alive... is the game paused??? Whats the state of things)
        {
            //if our character is grounded
            if (_characterController.isGrounded)
            {
                //set moveDir to the inputs direction

                _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                //moveDir's forward is changed from global z (forward) to the Game Objects local Z (forward)//allows us to move where player is facing
                _moveDirection = transform.TransformDirection(_moveDirection);

                //moveDir is multiplied by speed so we move at a decent pace
                _moveDirection *= _movespeed;

                /*
                 
                 short hand:
                _moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _moveSpeed);

                */

                //if the input button for jump is pressed then    

                if (Input.GetButton("Jump"))
                {
                    _moveDirection.y = _jumpSpeed;     //our moveDir.y is equal to our jump speed
                }

                if (Input.GetButton("Sprint"))
                {
                    _movespeed = _sprintSpeed;    
                }

                if (Input.GetButton("Crouch"))
                {
                    _movespeed = _crouchSpeed;
                }


            }

            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            _moveDirection.y -= _gravity * Time.deltaTime;

            //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime
            _characterController.Move(_moveDirection * Time.deltaTime);

        }

    }

    #endregion
}










