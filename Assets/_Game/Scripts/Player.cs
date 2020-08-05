using System;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

namespace _Game.Scripts
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public Dictionary<string, string> Iventory;
        
        public UnityArmatureComponent horizontalArmature;
        public UnityArmatureComponent verticalArmature;
        
        private PlayerMovement _movement;
        private Animation _animation;
        
        private void Start()
        {
            Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();

            _movement = new PlayerMovement(myRigidbody, speed);
            _animation = new Animation(horizontalArmature, verticalArmature);
        }
    }
}