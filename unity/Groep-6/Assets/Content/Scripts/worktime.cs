using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class worktime : MonoBehaviour
{
    public GameObject loader;
    public Slider slider;
    float TotalTime;
    float TimeGone;
    float Procent;
    float left;
    
    //laat zijn  en balk dat groeid door percentage tusen 0 en 100
    //
    /*public void SetFloat(float value)
    {
            Procent = Mathf.Lerp(0, TotalTime, left / 100);
            left += 0.5f * Time.deltaTime;
         if (left > 1.0f)
         {
             float temp = TotalTime;
             TotalTime = 0;
             0 = temp;
             left = 0.0f;
         }
         

        while (TimeGone!= TotalTime)
        {
            float procent = 0;
            float progress = Mathf.Clamp01(procent);
            slider.value = progress;

            yield return null;
        }
        //StartCoroutine(tijd(value));
    } */
    
    
}
