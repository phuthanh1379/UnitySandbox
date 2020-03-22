using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour {
    public Transform hoursTransform, minutesTransform, secondsTransform;
    private const float 
        degPerHour = 30f, 
        degPerMinute = 6f,
        degPerSecond = 6f;
    public bool continuous;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (continuous) {
            UpdateContinuous();
        }
        else {
            UpdateDiscrete();
        }
    }
    
    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        // Rotate the hour arm
        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degPerHour, 0f);

        // Rotate the minute arm
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degPerMinute, 0f);

        // Rotate the second arm
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degPerSecond, 0f);
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        // Rotate the hour arm
        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degPerHour, 0f);

        // Rotate the minute arm
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degPerMinute, 0f);

        // Rotate the second arm
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degPerSecond, 0f);
    }
}