using System;
using System.Collections.Generic;
using Cinemachine;
using DragonBones;
using UnityEngine;

namespace _Game.Scripts
{
    public class Player : MonoBehaviour
    {
        public CinemachineVirtualCamera camera;
        public float cameraMinOffset;
        public float cameraMaxOffset;
        public float cameraSpeed;
        
        public float maxSpeed;
        public Dictionary<string, string> Iventory;
        
        public UnityArmatureComponent horizontalArmature;
        public UnityArmatureComponent verticalArmature;

        private PlayerMovement _movement;
        private Animation _animation;
        private CameraManager _cameraManager;

        private Rigidbody2D myRigidbody; 
        
        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();

            _movement = new PlayerMovement(myRigidbody, maxSpeed);
            _animation = new Animation(horizontalArmature, verticalArmature);
            _cameraManager = new CameraManager(camera, cameraMinOffset, cameraMaxOffset, cameraSpeed);
        }

        private void Update()
        {
            float min = 0;
            float currentSpeed = myRigidbody.velocity.magnitude;
            float max = maxSpeed;
            float normalizedFloat = (currentSpeed - min) / (max - min);
            normalizedFloat = Mathf.Clamp(normalizedFloat, 0, 1);
            _cameraManager.ChangeOffset(normalizedFloat);
        }
    }
}