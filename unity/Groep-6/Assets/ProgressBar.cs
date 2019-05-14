using UnityEngine;
public class ProgressBar : MonoBehaviour
{
    RectTransform barback, bar;
    public void SetFloat(float value)
    {
        bar.localScale = new Vector3(Mathf.Lerp(0, barback.localScale.y, value / 100), barback.localScale.y, barback.localScale.z);
    }
    private void Start()
    {
        barback = GetComponent<RectTransform>();
        bar = this.transform.GetChild(0).GetComponent<RectTransform>();
    }
}
