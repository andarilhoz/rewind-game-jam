﻿using System;
using UnityEngine;

namespace _Game.Scripts.Input
{
    public class KeyboardInput : MonoBehaviour
    {
        public event Action<Vector2> OnInput;

        #region Singleton

        private static KeyboardInput instance;

        public static KeyboardInput Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = FindObjectOfType<KeyboardInput>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            if ( instance == null )
            {
                instance = this;
            }
        }

        #endregion

        private void Update()
        {
            ListenInput();
        }

        public void ListenInput()
        {
            float horizontalMove = UnityEngine.Input.GetAxis("Horizontal");
            float verticalMove = UnityEngine.Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontalMove, verticalMove);
            OnInput?.Invoke(direction);
        }
    }
}