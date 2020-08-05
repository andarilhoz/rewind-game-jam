using System;
using _Game.Scripts.Input;
using DragonBones;
using UnityEngine;

namespace _Game.Scripts
{
    public class Animation
    {
        public float animationThreshold = 0.05f;
        
        private UnityArmatureComponent _horizontalArmature;
        private UnityArmatureComponent _verticalArmature;
        
        private UnityArmatureComponent currentArmature;
        private UnityArmatureComponent disableArmature;
        private bool hasItem;
        private bool backward;
        
        
        public Animation(UnityArmatureComponent horizontalArmature, UnityArmatureComponent verticalArmature)
        {
            _horizontalArmature = horizontalArmature;
            _verticalArmature = verticalArmature;

            currentArmature = _verticalArmature;
            disableArmature = _horizontalArmature;
            
            disableArmature.gameObject.SetActive(false);
            currentArmature.gameObject.SetActive(true);    
                
            KeyboardInput.Instance.OnInput += UpdateMovement;
        }

        public void UpdateMovement(Vector2 changeAnimation)
        {
            bool isMoving = changeAnimation != Vector2.zero && changeAnimation.magnitude > animationThreshold;
            bool horizontalMovement = Mathf.Abs(changeAnimation.x) > Mathf.Abs(changeAnimation.y);
            
            backward = Math.Abs(changeAnimation.y) < animationThreshold ? backward : changeAnimation.y > 0;
            
            string animationPrefix = isMoving ? "run" : "idle";
            string animationInterfix = hasItem ? "_item" : "";
            string animationSuffix = backward && !horizontalMovement ? "_back" : "";

            string animationName = animationPrefix + animationInterfix + animationSuffix;

            if (isMoving)
            {
                currentArmature = horizontalMovement ? _horizontalArmature : _verticalArmature;
                disableArmature = horizontalMovement ? _verticalArmature : _horizontalArmature;
            
                disableArmature.gameObject.SetActive(false);
                currentArmature.gameObject.SetActive(true);    
            }

            currentArmature.animation.timeScale = isMoving ? 1f : .5f;
            
            if(currentArmature.animation.lastAnimationName != animationName)
                currentArmature.animation.Play(animationName);

            currentArmature._armature.flipX = horizontalMovement && changeAnimation.x < 0;
        }
    }
}