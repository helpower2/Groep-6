using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private RectTransform gridRect;
    private UnlockMenuPanelInstantiator unlockMenuPanelInstantiator;

    private float minPos = 0.0f, maxPos;

    private void Start()
    {
        gridRect = transform.GetChild(0).GetComponent<RectTransform>();
        unlockMenuPanelInstantiator = FindObjectOfType<UnlockMenuPanelInstantiator>();
        maxPos = GetMax(Utilities.FindGameObjectOrError("UnlockMenuGrid").GetComponent<UnityEngine.UI.VerticalLayoutGroup>(), unlockMenuPanelInstantiator.prefab, unlockMenuPanelInstantiator.childCount);
    }

    private float GetMax(UnityEngine.UI.VerticalLayoutGroup _verticalLayoutGroup, GameObject _gameObject, int _childCount)
    {
        var effectiveFloat = 0f;
        var gridSpacing = _verticalLayoutGroup.spacing;
        var prefabSize = _gameObject.GetComponent<RectTransform>().sizeDelta.y;
        var size = (prefabSize * _childCount) + (gridSpacing * (_childCount + 1));
        var scrollerViewportSize = Screen.height - Utilities.FindGameObjectOrError("BottomPanel").GetComponent<RectTransform>().sizeDelta.y;
        Debug.Log("Screen height is " + Screen.height);
        if (size > scrollerViewportSize)
        {
            effectiveFloat = size - scrollerViewportSize;
        }
        else
        {
            effectiveFloat = 0;
        }
        Debug.Log(size);
        return effectiveFloat;
    }


    private void Update()
    {
        var clampedPos = new Vector2(0.0f,Mathf.Clamp(gridRect.anchoredPosition.y,  minPos, maxPos));
        gridRect.anchoredPosition = clampedPos;
        
    }
}
