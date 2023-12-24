using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovementManager))]
public class Gravity : MonoBehaviour
{
    private PlayerMovementManager _playerMovementManager;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovementManager = GetComponent<PlayerMovementManager>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Apply();
    }
    
    private void Apply()
    {
        _playerMovementManager.playerVelocity += Vector3.down * (_playerMovementManager.gravity * _playerMovementManager.gravityMultiplier * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _playerMovementManager.playerVelocity.y = Math.Max(_playerMovementManager.playerVelocity.y, -0.5f);
        }
    }
}
