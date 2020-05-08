using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Water : MonoBehaviour
{
    private float cooldownTimeLeft_;
    private float nextReadyTime_;
    [SerializeField] private float cooldownDuration_;
    [SerializeField] private int glassAmount_;
    [SerializeField] private int pointsDecrease_;
    [SerializeField] private ThermometerControl thermometer_;
    [SerializeField] private GoogleARCore.Examples.AugmentedFaces.FaceFilterSwitch faceFilterSwitch_;
    [SerializeField] private TextMeshProUGUI textComponent_;
    [SerializeField] private Image darkMask_;

    void Awake()
    {
        faceFilterSwitch_ = FindObjectOfType<GoogleARCore.Examples.AugmentedFaces.FaceFilterSwitch>();
        nextReadyTime_ = 0f;
    }

    void Start()
    {
        textComponent_.text = glassAmount_.ToString();
    }

    void Update()
    {
        bool cooldownIsComplete = (Time.time > nextReadyTime_);
        textComponent_.text = glassAmount_.ToString();
        faceFilterSwitch_.DetectHeadShaking();
        if (cooldownIsComplete)
        {
            if (faceFilterSwitch_.DetermineShakeHeads() && glassAmount_ > 0)
            {
                Drink();
            }
        }
        else
        {
            Cooldown();
        }
    }

    public void Drink()
    {
        cooldownTimeLeft_ = cooldownDuration_;
        nextReadyTime_ = Time.time + cooldownDuration_;
        thermometer_.LoseLevel(pointsDecrease_);
        thermometer_.level = Mathf.Clamp(thermometer_.level, 0, 100);
        glassAmount_ -= 1;
    }

    private void Cooldown() //displays visual information about the cooldown and countdowns cd
    {
        cooldownTimeLeft_ -= Time.deltaTime;
        darkMask_.fillAmount = (cooldownTimeLeft_ / cooldownDuration_);
    }
}
