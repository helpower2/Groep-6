using DG.Tweening;
using UnityEngine;
public static class Extensions
{
    public static void DestroyChilds(this Transform t)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
            MonoBehaviour.Destroy(t.GetChild(i).gameObject);
    }

    public static void ChildsActiveState(this Transform t, bool state)
    {
        for (int i = t.childCount - 1; i >= 0; i--)
            t.GetChild(i).gameObject.SetActive(state);
    }

    // Generic
    public static void Reset(this Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localEulerAngles = Vector3.zero;
        t.localScale = Vector3.one;
    }

    // Spriterenderer
    public static void SetColor(this SpriteRenderer spriteRenderer, Color color)
    {
        spriteRenderer.color = color;
    }

    public static void SetSprite(this SpriteRenderer spriteRenderer, Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    // Effects
    public static void Effect_Jiggle(this Transform t, float time)
    {
        time /= 3f;
        t.DOScale(0.9f, time).SetEase(Ease.Linear);
        t.DOScale(1.1f, time).SetEase(Ease.Linear).SetDelay(time);
        t.DOScale(1f, time).SetEase(Ease.Linear).SetDelay(time * 2);
    }

    public static void Effect_Shake(this Transform t, float time, float strength = 1)
    {
        t.DOShakePosition(time, strength);
    }
}
public static class DataExtensions
{
    public static void Save<T>(this T file) where T : Data.DataFile
    {
        DataManager.Save(file, typeof(T).Name);
    }
    public static void load<T>(ref T _param, string _name)
    {
        DataManager.Load(ref _param, _name);
    }
}