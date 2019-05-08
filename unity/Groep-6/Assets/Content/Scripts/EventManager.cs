using UnityEngine;

public static class EventManager
{
    public delegate void UIStateChange(UIStateManager.UIState UIState);
    public static UIStateChange UIStateChangeEvent;

    public static void CallUIStateChange(UIStateManager.UIState _UIState)
    {
        if (GameObject.FindObjectOfType<UIWindowSystem>().gameObject.GetComponent<UIWindowSystem>().shouldRun)
        {
            UIStateChangeEvent?.Invoke(_UIState);
        }
    }
}
