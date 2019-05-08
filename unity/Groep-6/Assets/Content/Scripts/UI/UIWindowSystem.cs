//To disable useless DebugLogWarnings
#pragma warning disable 649
using System.Collections;
using UnityEngine;

public class UIWindowSystem : MonoBehaviour
{
    public GameObject[] ButtonTabs;
    public GameObject TabFooter;

    [SerializeField, Range(0.5f, 5.0f)]
    private float speed;

    private bool _shouldRun = true;
    public bool shouldRun { get => _shouldRun; private set => _shouldRun = value; }

    private IEnumerator Caroutine;

    private IEnumerator AnimateTabFooter(RectTransform _currentTransform, float target, RectTransform _rect, float _startingWidth, float _targetWidth, float _timePassed = 0.0f)
    {
        yield return new WaitForEndOfFrame();
        _timePassed += Time.deltaTime;
        _currentTransform.anchoredPosition = new Vector2(Mathf.Lerp(_currentTransform.anchoredPosition.x, target, _timePassed * speed), 0.0f);
        _rect.sizeDelta = new Vector2(Mathf.Lerp(_startingWidth, _targetWidth, _timePassed * speed * 2), _rect.sizeDelta.y);
        if (!(_timePassed * speed >= 1.0f))
        {
            StartCoroutine(AnimateTabFooter(_currentTransform, target, _rect, _startingWidth, _targetWidth, _timePassed));
        }
        if (_timePassed * speed > 0.9f)
        {
            shouldRun = true;
        }
    }

    private void Start()
    {
        var rect = TabFooter.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(ButtonTabs[0].GetComponent<RectTransform>().anchoredPosition.x, 0.0f);
        rect.sizeDelta = new Vector2(ButtonTabs[0].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().preferredWidth, rect.sizeDelta.y);
        ColorButtons(0);
    }

    private void OnValidate()
    {
        Start();
    }

    public void ColorButtons(int _index)
    {
        for (int i = 0; i < ButtonTabs.Length; i++)
        {
            var text = ButtonTabs[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
            if (_index != i)
            {
                text.color = Color.grey;
            }
            else
            {
                text.color = Color.white;
            }
        }
    }


    public void StartAnimateTabFooterCaroutine(RectTransform _currentTransform, Vector2 _targetPosition, int _index)
    {
        var rect            = TabFooter.GetComponent<RectTransform>();
        var distance        = _targetPosition.x - _currentTransform.anchoredPosition.x;
        var target          = _currentTransform.anchoredPosition.x + distance;
        var targetWidth     = ButtonTabs[_index].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().preferredWidth;
        var startingWidth   = rect.sizeDelta.x;
        Caroutine           = AnimateTabFooter(_currentTransform, target, rect, startingWidth, targetWidth);
        shouldRun           = false;
        if (Caroutine != null)
        {
            StopCoroutine(Caroutine);
        }
        StartCoroutine(Caroutine);
    }

}
