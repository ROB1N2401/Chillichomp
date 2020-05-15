using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GoogleARCore.Examples.AugmentedFaces;

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


    //this is your object that you want to have the UI element hovering over
    GameObject WorldObject;

    //this is the ui element
    RectTransform UI_Element;


    void Awake()
    {
        this.transform.position = new Vector3(1.5f, 1.1f, 6);
        darkMask_.transform.position = new Vector3(130, 1380.9f, 0);
        faceFilterSwitch_ = GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>();
        //faceFilterSwitch_ = FindObjectOfType<GoogleARCore.Examples.AugmentedFaces.FaceFilterSwitch>();
        nextReadyTime_ = 0f;
    }

    void Start()
    {
        textComponent_.text = glassAmount_.ToString();
        darkMask_.fillAmount = 0;
    }

    void Update()
    {   
        bool cooldownIsComplete = (Time.time > nextReadyTime_);
        textComponent_.text = glassAmount_.ToString();
        //faceFilterSwitch_.DetectHeadShaking();
    
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
        GameObject.Find("Audio Source").GetComponent<AudioControl>().DrinkWater();
        cooldownTimeLeft_ = cooldownDuration_;
        nextReadyTime_ = Time.time + cooldownDuration_;
        thermometer_.LoseLevel(pointsDecrease_); 
        glassAmount_ -= 1;
    }

    private void Cooldown() //displays visual information about the cooldown and countdowns cd
    {
        cooldownTimeLeft_ -= Time.deltaTime;
        darkMask_.fillAmount = (cooldownTimeLeft_ / cooldownDuration_);
    }
}
