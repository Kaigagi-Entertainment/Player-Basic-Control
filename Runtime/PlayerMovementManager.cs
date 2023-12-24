using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementManager : MonoBehaviour
    {
        public float walkSpeed = 10;
        public float runSpeed = 20;
        public float jumpForce = 2f; 
        public float gravityMultiplier = 1f;
        public float rotateSpeed;
        public float rotateSmoothTime = 0.03f;
        public LayerMask groundLayer;
        public Vector2 direction;
        public Transform mesh;

        public Vector3 playerVelocity = Vector3.zero;
        public readonly float gravity = 9.8f;
        
        private CharacterController _characterController;
        

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ApplyVelocity();
        }
        
        private void ApplyVelocity()
        {
            _characterController.Move(playerVelocity * Time.fixedDeltaTime);
        }
    }
}