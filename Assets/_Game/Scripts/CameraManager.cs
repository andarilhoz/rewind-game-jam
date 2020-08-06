using Cinemachine;
using UnityEngine;

namespace _Game.Scripts
{
    public class CameraManager
    {
        private CinemachineVirtualCamera _camera;
        private float _minOffset;
        private float _maxOffset;

        private float _cameraSpeed;
        
        public CameraManager(CinemachineVirtualCamera camera, float minOffset, float maxOffset, float cameraSpeed)
        {
            _camera = camera;
            _minOffset = minOffset;
            _maxOffset = maxOffset;
            _cameraSpeed = cameraSpeed;
        }


        public void ChangeOffset(float speed)
        {
            float targetZoom = speed * _maxOffset;
            targetZoom = Mathf.Lerp(_camera.m_Lens.OrthographicSize, targetZoom, _cameraSpeed);
            _camera.m_Lens.OrthographicSize = Mathf.Clamp(targetZoom, _minOffset, _maxOffset);
        }
    }
}