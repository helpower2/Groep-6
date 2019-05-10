using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventGameObject : UnityEvent<GameObject> { }


public class ClickManager : MonoBehaviour
{
    public EventGameObject OnClick = new EventGameObject();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                Clickeble clickeble = hitInfo.transform.GetComponent<Clickeble>();
                if (clickeble != null)
                {
                    print("It's working");
                    OnClick.Invoke(clickeble.gameObject);
                    clickeble.OnClick.Invoke();
                }
            }
        }
        if (Input.touchCount == 1)
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hitInfo) && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Clickeble clickeble = hitInfo.transform.GetComponent<Clickeble>();
                if (clickeble != null)
                {
                    print("It's working");
                    OnClick.Invoke(clickeble.gameObject);
                    clickeble.OnClick.Invoke();
                }
            }
        }
    }
}
