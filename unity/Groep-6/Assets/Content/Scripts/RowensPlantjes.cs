﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IsWorkerInRoom))]
public class RowensPlantjes : MonoBehaviour
{
    public UnityFloat unityFloat;
    private float growSpeed;
    private IsWorkerInRoom isWorker;
    [SerializeField] private float progress = 0f;
    public float Progress { get { return progress; } }
    public float GrowSpeed { get { return growSpeed; } set { growSpeed = value; } }

    private void Start()
    {
        isWorker = GetComponent<IsWorkerInRoom>();
        progress = 0f;
    }

    private void Update()
    {
        float speed = 0;
        foreach (var human in isWorker.humanStats)
        {
            speed += human.Speed;
        }
        speed /= isWorker.humans.Count;
        //Debug.Log(speed + " : Speed");
        float temp = ((Time.deltaTime * speed));
        //Debug.Log(temp + "Temp");
        if (!float.IsNaN(temp))
        {
            progress = temp + progress;
            unityFloat.Invoke(progress);
        }
      
        //Debug.Log(progress + " : Progress");
        if (progress >= 100f)
        {
            //weed is done
            progress = 0f;
            Debug.Log("done");
        }
    }
}
[Serializable]
public class UnityFloat : UnityEvent<float> { }