using _Game.Scripts.Input;
using UnityEngine;

namespace _Game.Scripts
{
    public class PlayerMovement
    {
        private float _speed;
        private Rigidbody2D _playerRigidbody2D;
        private float movementThreshold = 0.2f;
        public PlayerMovement(Rigidbody2D playerRigidbody2D, float speed)
        {
            _speed = speed;
            _playerRigidbody2D = playerRigidbody2D;
            KeyboardInput.Instance.OnInput += MovePlayer;
        }

        private void MovePlayer(Vector2 direction)
        {
            if (direction.normalized.magnitude < movementThreshold)
            {
                _playerRigidbody2D.velocity = Vector2.zero;
                return;
            }

            _playerRigidbody2D.velocity = direction * _speed;
        }
    }
}