//To disable useless DebugLogWarnings
#pragma warning disable 649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MonoBehaviour
{
    public enum UIState
    {
        PlayMode,
        UnlockingMenu,
        SettingsMenu
    }

    private UIState _currentUIState = UIState.PlayMode;

    private UIState currentUIState
    {
        get
        {
            return _currentUIState;
        }
        set
        {
            var UIWS = GetComponent<UIWindowSystem>();
            UIWS.StartAnimateTabFooterCaroutine(UIWS.TabFooter.GetComponent<RectTransform>(), UIWS.ButtonTabs[(int)value].GetComponent<RectTransform>().anchoredPosition, (int)value);
            UIWS.ColorButtons((int)value);
            callSwitchStates((int)value);
            _currentUIState = value;
        }
    }

    [Header("Object References")]
    [SerializeField]
    private GameObject[] UIState_PlayModeObjects;

    [SerializeField]
    private GameObject[] UIState_UnlockingMenuObjects;

    [SerializeField]
    private GameObject[] UIState_SettingsMenuObjects;

    public GameObject[] bottomPanelButtons;

    private Dictionary<UIState, GameObject[]> UIState_LookUpTable;

    private void Start()
    {
        //UIState_LookUpTable definition
        UIState_LookUpTable = new Dictionary<UIState, GameObject[]>() {
            { UIState.PlayMode, UIState_PlayModeObjects },
            { UIState.UnlockingMenu, UIState_UnlockingMenuObjects },
            { UIState.SettingsMenu, UIState_SettingsMenuObjects }
        };
        callSwitchStates(0);
    }

    private void callSwitchStates(int _value)
    {
        List<GameObject[]> gameObjects = new List<GameObject[]>();
        foreach (var item in UIState_LookUpTable.Values)
        {
            gameObjects.Add(item);
        }
        UIWindowSystemUtilities.switchStates(_value, gameObjects);
    }

    public void SetState(UIState _targetState)
    {
        currentUIState = _targetState;
    }

    private void OnEnable()
    {
        EventManager.UIStateChangeEvent += SetState;
    }

    private void OnDisable()
    {
        EventManager.UIStateChangeEvent -= SetState;
    }
}


