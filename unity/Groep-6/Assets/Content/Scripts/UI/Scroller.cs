using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    private RectTransform gridRect;
    [SerializeField]
    public UnlockMenuPanelInstantiator unlockMenuPanelInstantiator;

    private float minPos = 0.0f, maxPos;

    private void Start()
    {
        gridRect = transform.GetChild(0).GetComponent<RectTransform>();
        if (unlockMenuPanelInstantiator != null)
        {
            maxPos = GetMax(unlockMenuPanelInstantiator.spacing, unlockMenuPanelInstantiator.prefab, unlockMenuPanelInstantiator.childCount);
        }
    }

    private void OnEnable()
    {
        
        if (unlockMenuPanelInstantiator != null)
        {
            if (gridRect != null)
            {
                gridRect.anchoredPosition = Vector2.zero;
            }
            maxPos = GetMax(unlockMenuPanelInstantiator.spacing, unlockMenuPanelInstantiator.prefab, unlockMenuPanelInstantiator.childCount);
        }
    }

    private float GetMax(float _spacing, GameObject _gameObject, int _childCount)
    {
        var effectiveFloat = 0f;
        var prefabSize = _gameObject.GetComponent<RectTransform>().sizeDelta.y;
        var size = (prefabSize * _childCount) + (_spacing * (_childCount + 1));
        var scrollerViewportSize = Screen.height - Utilities.FindGameObjectOrError("BottomPanel").GetComponent<RectTransform>().sizeDelta.y;
        if (size > scrollerViewportSize)
        {
            effectiveFloat = size - scrollerViewportSize;
        }
        else
        {
            effectiveFloat = 0;
        }
        Debug.Log("size is : " + size);
        return effectiveFloat;
    }


    private void Update()
    {
        var clampedPos = new Vector2(0.0f,Mathf.Clamp(gridRect.anchoredPosition.y,  minPos, maxPos));
        gridRect.anchoredPosition = clampedPos;
    }
}
