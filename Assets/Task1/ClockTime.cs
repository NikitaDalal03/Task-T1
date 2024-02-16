using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClockTime : MonoBehaviour
{

    public Transform hoursHand;
    public Transform minutesHand;
    public Transform secondsHand;

    public bool Continues;
    public string oldSeconds;

    private void Update()
    {
        if (Continues)
        {
            ContinuesMotion();
        }
        else
        {
            TickMotion();
        }

        string Seconds = System.DateTime.UtcNow.ToString("ss");

        if (Seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = Seconds;

    }


    void UpdateTimer()
    {
        //Just to display the correct time on console
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        Debug.Log(hoursInt + ":" + minutesInt + ":" + secondsInt);
       

    }


    void ContinuesMotion()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursHand.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * 30f, 0f);
        minutesHand.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * 6f, 0f);
        secondsHand.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * 6f, 0f);

    }

    void TickMotion()
    {
        DateTime time = DateTime.Now;

        hoursHand.localRotation = Quaternion.Euler(0f, time.Hour * 30f, 0f);
        minutesHand.localRotation = Quaternion.Euler(0f, time.Minute * 6f, 0f);
        secondsHand.localRotation = Quaternion.Euler(0f, time.Second * 6f, 0f);

    }
}







