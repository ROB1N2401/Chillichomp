using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime_;
    public float currentTime_;

    public Timer(float targetTime_in)
    {
        targetTime_ = targetTime_in;
        currentTime_ = 0.0f;
    }

    public void Update()
    {
        currentTime_ += Time.deltaTime;
    }

    public void SetTime()
}
