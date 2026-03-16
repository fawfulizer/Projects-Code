using Lean.Touch;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour


{
    [Header("Camera Settings")]
    public Camera targetCamera;
    public float zoomSpeed = 15f;
    public float minZoom = 5f;
    public float maxZoom = 40f;

    private void Awake()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    private void OnEnable()
    {
        LeanTouch.OnGesture += HandleGesture;
    }

    private void OnDisable()
    {
        LeanTouch.OnGesture -= HandleGesture;
    }

    private void HandleGesture(List<LeanFinger> fingers)
    {
        // Only if two or more fingers are used
        if (fingers.Count < 2)
            return;

        float pinchScale = LeanGesture.GetPinchScale(fingers);

        if (pinchScale != 1f)
        {
            // Convert pinch scale to FOV delta
            float zoomChange = (1f - pinchScale) * zoomSpeed;

            float newFov = targetCamera.fieldOfView + zoomChange;
            targetCamera.fieldOfView = Mathf.Clamp(newFov, minZoom, maxZoom);
        }
    }
}

