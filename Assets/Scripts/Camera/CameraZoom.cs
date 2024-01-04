using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace MenezesMovementSystem
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Range(0,10f)] private float defaultDistance = 6;
        [SerializeField] [Range(0,10f)] private float minimumDistance = 1;
        [SerializeField] [Range(0,10f)] private float maximumDistance = 6;
        
        [SerializeField] [Range(0,10f)] private float smoothing = 6;
        [SerializeField] [Range(0,10f)] private float zoomSensitivity = 6;

        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider inputProvider;

        private float currentTargetDistance;
        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();
            currentTargetDistance = defaultDistance;
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            float zoomVaalue = inputProvider.GetAxisValue(2) * zoomSensitivity;
            currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomVaalue, minimumDistance, maximumDistance);
            float currentDistance = framingTransposer.m_CameraDistance;
            if (currentDistance == currentTargetDistance)
            {
                return;
                
            }

            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);
            framingTransposer.m_CameraDistance = lerpedZoomValue;

        }
    }
}
