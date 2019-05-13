using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class EventGameObject : UnityEvent<GameObject> { }


public class ClickManager : MonoBehaviour
{
    public EventGameObject OnClick = new EventGameObject();

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0))    // is the touch on the GUI
        {
            // GUI Action
            return;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("muis");
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, direction: Vector2.up);

            if (hitInfo.transform != null)
            {
                Debug.Log("Hit");
                Clickeble clickeble = hitInfo.transform.GetComponent<Clickeble>();
                if (clickeble != null)
                {
                    print("It's working");
                    OnClick.Invoke(clickeble.gameObject);
                    clickeble.OnClick.Invoke();
                }
                else
                {
                    Debug.Log("clickeble");
                }
            }
        }
        /*if (Input.touchCount == 1)
        {
            Debug.Log("touch");
            RaycastHit hitInfo = new RaycastHit();
            if (Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hitInfo) && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Hit");
                Clickeble clickeble = hitInfo.transform.GetComponent<Clickeble>();
                if (clickeble != null)
                {
                    print("It's working");
                    OnClick.Invoke(clickeble.gameObject);
                    clickeble.OnClick.Invoke();
                }
                else
                {
                    Debug.Log("clickeble");
                }
            }
        }*/
    }
}
