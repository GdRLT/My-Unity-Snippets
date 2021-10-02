﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExecuteMethodsSlowly : MonoBehaviour
{
    public Queue<Action> ActionQueueList = new Queue<Action>();
    public float delay;

    //Entered Methods will Show slowly by "delay" time.
    async void ShowSlowly()
    {
        while (ActionQueueList.Count > 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));

            Action action = ActionQueueList.Dequeue();
            action();
        }
    }

    //Add 3 Sample Method To Queue 
    private void Start()
    {
        ActionQueueList.Enqueue(A);
        ActionQueueList.Enqueue(B);
        ActionQueueList.Enqueue(C);

        ShowSlowly();
    }

    private void A()
    {
        Debug.Log("A");
    }

    private void B()
    {
        Debug.Log("B");
    }

    private void C()
    {
        Debug.Log("C");
    }

}