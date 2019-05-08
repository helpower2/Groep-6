//To disable useless DebugLogWarnings
#pragma warning disable 649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;


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
            switchStates(value);
            _currentUIState = value;
        }
    }


    [SerializeField]
    private GameObject[] UIState_PlayModeObjects;

    [SerializeField]
    private GameObject[] UIState_UnlockingMenuObjects;

    [SerializeField]
    private GameObject[] UIState_SettingsMenuObjects;

    private Dictionary<UIState, GameObject[]> UIState_LookUpTable;

    private void Start()
    {
        //UIState_LookUpTable definition
        UIState_LookUpTable = new Dictionary<UIState, GameObject[]>() {
            { UIState.PlayMode, UIState_PlayModeObjects },
            { UIState.UnlockingMenu, UIState_UnlockingMenuObjects },
            { UIState.SettingsMenu, UIState_SettingsMenuObjects }
        };

        GameObject.Find("PlayModeButton").GetComponent<Button>().onClick.AddListener(() => EventManager.CallUIStateChange(UIState.PlayMode));
        GameObject.Find("UnlockingMenuButton").GetComponent<Button>().onClick.AddListener(() => EventManager.CallUIStateChange(UIState.UnlockingMenu));
        GameObject.Find("SettingsMenuButton").GetComponent<Button>().onClick.AddListener(() => EventManager.CallUIStateChange(UIState.SettingsMenu));
    }

    /// <summary>
    /// UIStateSwitcher
    /// <para>
    /// Manages the loading and unloading of relevant GameObjects related to the old and target UIState.
    /// </para>
    /// </summary>
    /// <param name="_targetState">UIState switching to</param>
    private void switchStates(UIState _targetState)
    {
        foreach (var stateKey in UIState_LookUpTable.Keys)
        {
            if (stateKey != _targetState)
            {
                var objectsToBeDisabled = UIState_LookUpTable[stateKey].Except(UIState_LookUpTable[_targetState]).ToList();
                foreach (var objectToBeDisabled in objectsToBeDisabled)
                {
                    objectToBeDisabled.SetActive(false);
                }
            }
            else
            {
                var objectsToBeEnabled = UIState_LookUpTable[stateKey];
                foreach (var objectToBeEnabled in objectsToBeEnabled)
                {
                    objectToBeEnabled.SetActive(true);
                }
            }
        }
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


