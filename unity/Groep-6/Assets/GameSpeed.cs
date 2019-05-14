using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSpeed : MonoBehaviour
{
    public UnityEvent time = new UnityEvent();
   public float Speed { get { return Time.timeScale; } set { Time.timeScale = value; time.Invoke(); } }

    public void SpeedUp()
    {
        if (Speed <= 2)
        {
            Speed += 1;
        }
    }
    public void SlowDown()
    {
        if (Speed >= 1)
        {
            Speed -= 1;
        }
    }
}
