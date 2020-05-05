using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float targetTime_;
    public float currentTime_;

    public Timer(float targetTime_in)
    {
        targetTime_ = targetTime_in;
        currentTime_ = 0.0f;
    }

    public void Refresh()
    {
        currentTime_ = 0f;
    }

    public bool IsDone()
    {
        return (currentTime_ >= targetTime_);
    }

    public void UpdateTimer()
    {
        currentTime_ += Time.deltaTime;
    }
}
