using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPanel : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.UIStateChangeEvent += switchStates;
    }

    private void OnDisable()
    {
        EventManager.UIStateChangeEvent -= switchStates;
    }

    private void switchStates(UIStateManager.UIState _targetState)
    {
        var UIWS = GetComponent<UIWindowSystem>();
        UIWS.StartAnimateTabFooterCaroutine(UIWS.TabFooter.GetComponent<RectTransform>(), UIWS.ButtonTabs[(int)_targetState].GetComponent<RectTransform>().anchoredPosition, (int)_targetState);
        UIWS.ColorButtons((int)_targetState);
    }
}
