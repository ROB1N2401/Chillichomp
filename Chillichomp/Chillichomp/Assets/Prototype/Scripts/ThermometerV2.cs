using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerV2 : MonoBehaviour
{
    public enum OverheatState
    {
        Ready,
        Cooldown,
        End
    }

    internal int currentLevel_; //spiciness level

    [SerializeField] private List<Sprite> allSprites_; //storing sprites of different states, where 0 is the lowest temperature and 3 is overheating
    [SerializeField] private float overheatTime_;
    [SerializeField] private Timer timer_;
    private SpriteRenderer sr_;
    public OverheatState currentState;

    void Awake()
    {
        sr_ = GetComponent<SpriteRenderer>();
        overheatTime_ = 3f;
        currentLevel_ = 0;
        currentState = OverheatState.Ready;
        timer_ = new Timer(overheatTime_);
    }

    public void IncreaseTemperature(int spiciness_in)
    {
        currentLevel_ += spiciness_in;
    }

    public void DecreaseTemperature(int spiciness_in)
    {
        currentLevel_ -= spiciness_in;
    }

    public int cooldownCounter = 0;
    private void CoolDown()
    {
        FoodInteraction a = FindObjectOfType<FoodInteraction>();
        DeployFood b = FindObjectOfType<DeployFood>();
        cooldownCounter++;

        if (currentState == OverheatState.Ready)
        {
            sr_.sprite = allSprites_[8];
            a.Overheat();

            a.enabled = false;
            b.enabled = false;

            currentState = OverheatState.Cooldown;
        }

        if (currentState == OverheatState.End)
        {
            a.enabled = true;
            b.enabled = true;

            currentState = OverheatState.Ready;
            currentLevel_ = 0;

            a.CloseMouth();
        }

    }

    void Update()
    {
        if (currentLevel_ >= 0 && currentLevel_ <= 7)
        {
            sr_.sprite = allSprites_[currentLevel_];
        }
        else if (currentLevel_ > 7)
        {
            if (currentState == OverheatState.Ready)
            {
                CoolDown();
            }
            if (timer_.IsDone())
            {
                currentState = OverheatState.End;
                timer_.Refresh();
                CoolDown();
            }
            timer_.UpdateTimer();
        }
    }
}