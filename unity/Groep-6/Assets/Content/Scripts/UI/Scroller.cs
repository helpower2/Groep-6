using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private RectTransform GridRect;

    private float minPos = 0.0f, maxPos;

    private void Start()
    {
        GridRect = transform.GetChild(0).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        maxPos = GetMax();
    }

    private float GetMax()
    {
        var total = (GetComponentInChildren<UnlockMenuPanelInstantiator>().childCount * 240) - (Screen.height - Utilities.FindGameObjectOrError("BottomPanel").GetComponent<RectTransform>().sizeDelta.y);
        var effectiveFloat = total > 0 ? total : 0f;
        return effectiveFloat;
    }


    private void Update()
    {

        var clampedPos = new Vector2(0.0f,Mathf.Clamp(GridRect.anchoredPosition.y, minPos, maxPos));
    }
}
