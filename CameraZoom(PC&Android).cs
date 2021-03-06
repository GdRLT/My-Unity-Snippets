using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float MouseZoomSpeed; //15.0f;
    public float TouchZoomSpeed; //0.1f;
    public float ZoomMinBound; //2.5f;
    public float ZoomMaxBound; //7.5f;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, MouseZoomSpeed);
        }

        if (cam.orthographicSize < ZoomMinBound)
        {
            cam.orthographicSize = 2.5f;
        }
        else
        if (cam.orthographicSize > ZoomMaxBound)
        {
            cam.orthographicSize = 7.5f;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.orthographicSize += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, ZoomMinBound, ZoomMaxBound);
    }
}
