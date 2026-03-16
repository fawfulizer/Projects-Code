using UnityEngine;
using Lean.Touch;

public class OrthoPinchZoomCamera : MonoBehaviour
{
    public Camera targetCamera;

    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;
    public float minZoom = 2f;
    public float maxZoom = 20f;

    // Filter to get fingers used for gestures
    public LeanFingerFilter fingerFilter = new LeanFingerFilter(true);

    private void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        targetCamera.orthographic = true;
    }

    private void Update()
    {
        // Get fingers that are currently valid
        var fingers = fingerFilter.UpdateAndGetFingers();

        // We only want pinch if there are EXACTLY 2 fingers
        if (fingers.Count == 2)
        {
            // Get LeanTouch pinch scale
            float pinch = LeanGesture.GetPinchScale(fingers);

            // Ignore tap or tiny movements
            if (Mathf.Abs(1f - pinch) < 0.01f)
                return;

            float newSize = targetCamera.orthographicSize / pinch;

            targetCamera.orthographicSize =
                Mathf.Clamp(newSize, minZoom, maxZoom);
        }
    }
}
