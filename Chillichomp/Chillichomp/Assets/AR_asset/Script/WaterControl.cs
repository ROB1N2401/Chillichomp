using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GoogleARCore.Examples.AugmentedFaces;

public class WaterControl : MonoBehaviour
{
    private float nextReadyTime_;
    [SerializeField] private float cooldownDuration_;
    [SerializeField] private int glassAmount_;
    [SerializeField] private int pointsDecrease_;
    [SerializeField] private TextMeshProUGUI textComponent_;

    ////this is your object that you want to have the UI element hovering over
    //GameObject WorldObject;

    ////this is the ui element
    //RectTransform UI_Element;

    void Awake()
    {
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
        if (cooldownIsComplete)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineShakeHeads() 
                && glassAmount_ > 0)
            {
                if(!GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().CheckHitRoof())
                {
                    Drink();
                }
            }
        }
    }

    public void Drink()
    {
        GameObject.Find("Audio Source").GetComponent<AudioControl>().DrinkWater();
        nextReadyTime_ = Time.time + cooldownDuration_;
        GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().LoseLevel(pointsDecrease_);
        glassAmount_ -= 1;
    }

}
