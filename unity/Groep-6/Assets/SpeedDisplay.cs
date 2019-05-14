using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    [SerializeField] private List<Sprite> speeds = new List<Sprite>(4);
    [SerializeField] private Image display;

    public void updateDisplay()
    {
        float timescale = Time.timeScale;
        if (timescale == 0)
        {
            //pauzed show sprite 0
            display.sprite = speeds[0];
        }
        if (timescale >= 1 && timescale <= 2)
        {
            //speed is normal show sprite 1
            display.sprite = speeds[1];
        }
        if (timescale >= 2 && timescale <= 3)
        {
            //speed is speed show sprite 2
            display.sprite = speeds[2];
        }
        if (timescale >= 3 && timescale <= 4)
        {
            //speed is speed show sprite 3
            display.sprite = speeds[3];
        }
        

    }
}
