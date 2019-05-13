using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    private Camera camera;
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public Vector2 ZoomLimits;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (camera.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                float temp = deltaMagnitudeDiff * orthoZoomSpeed / 100;

                // Make sure the orthographic size never drops below zero.
                //camera.orthographicSize = Mathf.Max(camera.orthographicSize, ZoomLimits.x);

                if (camera.orthographicSize <= ZoomLimits.x && temp < 0)
                {
                    temp = 0;
                }
                if (camera.orthographicSize >= ZoomLimits.y && temp > 0)
                {
                    temp = 0;
                }
                camera.orthographicSize += temp;
                

            }
        }
        camera.orthographicSize = Mathf.Max(camera.orthographicSize, ZoomLimits.x);
    }
}
