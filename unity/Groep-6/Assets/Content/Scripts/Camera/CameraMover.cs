using UnityEngine;
public class CameraMover : MonoBehaviour
{
    public float speed = 0.1F;
    public Vector2 minPos;
    public Vector2 maxPos;
    [SerializeField] private Camera camera;
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Vector2 vector = touchDeltaPosition;
            if (transform.position.y <= minPos.y && touchDeltaPosition.y > 0)
            {
                vector.y = 0;
                Debug.Log("Y Min");
            }
            if (transform.position.y >= maxPos.y && touchDeltaPosition.y < 0)
            {
                vector.y = 0;
                Debug.Log("Y Max");
            }
            if (transform.position.x <= minPos.x && touchDeltaPosition.x > 0)
            {
                vector.x = 0;
                Debug.Log("X Min");
            }
            if (transform.position.x >= maxPos.x && touchDeltaPosition.x < 0)
            {
                vector.x = 0;
                Debug.Log("X Max");
            }
            transform.Translate((-vector.x * speed * camera.orthographicSize) / 400, (-vector.y * speed * camera.orthographicSize) / 400, 0);
        }
    }
}

