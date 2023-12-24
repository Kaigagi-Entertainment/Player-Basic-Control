using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerMovementManager))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        private PlayerMovementManager _playerMovementManager;
        private CharacterController _characterController;
        private void Start()
        {
            _playerMovementManager = GetComponent<PlayerMovementManager>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            MoveTo();
            Rotate();
        }

        private void MoveTo()
        {
            var direction = _playerMovementManager.direction;
            var walkSpeed = _playerMovementManager.walkSpeed;
            _playerMovementManager.playerVelocity.x = direction.x * walkSpeed;
            _playerMovementManager.playerVelocity.z = direction.y * walkSpeed;
        }
        
        private void Rotate()
        {
            var direction = _playerMovementManager.direction;
            if (direction is { x: 0, y: 0 })
            {
                return;
            }
            var targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(_playerMovementManager.mesh.transform.eulerAngles.y, targetAngle, ref _playerMovementManager.rotateSpeed, _playerMovementManager.rotateSmoothTime);
            _playerMovementManager.mesh.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            _playerMovementManager.direction = input;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Jump();
            }
        }
    
        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Sprint");
            }
        }
        
        private void Jump()
        {
            if (_characterController.isGrounded)
            {
                _playerMovementManager.playerVelocity.y += _playerMovementManager.jumpForce;
            }
        }
    }
}