using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Timer
//{
//    float time = 0.0f;
//    float currentTime = 0.0f;
//    void Update() { currentTime += Time.deltaTime; }
//    bool IsDone() { return (currentTime > time); }
//}
public class Thermometer : MonoBehaviour
{
    //public enum ThermometerState
    //{
    //    Normal,
    //    Overheated
    //}
    //ThermometerState currentState = ThermometerState.Normal;
    internal int currentLevel_; //spiciness level

    [SerializeField] private List<Sprite> allSprites_; //storing sprites of different states, where 0 is the lowest temperature and 3 is overheating
    private SpriteRenderer sr_;

    void Awake()
    {
        sr_ = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentLevel_ = 0;
    }

    public void IncreaseTemperature(int spiciness_in)
    {
        currentLevel_ += spiciness_in;
    }

    public void DecreaseTemperature(int spiciness_in)
    {
        currentLevel_ -= spiciness_in;
    }

    IEnumerator CoolDown()
    {
        //coroutinesStarted++;
        FoodInteraction a = FindObjectOfType<FoodInteraction>();
        DeployFood b = FindObjectOfType<DeployFood>();
        a.Overheat();

        yield return new WaitForSeconds(0.1f);

        a.enabled = false;
        b.enabled = false;

        yield return new WaitForSeconds(3f);

        a.enabled = true;
        b.enabled = true;

        currentLevel_ = 0;
        a.CloseMouth();
        //cooldown = false;
    }

    //public int coroutinesStarted = 0;
    //private bool cooldown = false;
    // Update is called once per frame
    void Update()
    {
        //if(currentState == ThermometerState.Normal)
        //{
        //    sr_.sprite = allSprites_[currentLevel_];
        //    if (currentLevel_ > 7) // Transition to OverheatedState
        //    {
        //        currentState = ThermometerState.Overheated;
        //        //starting a timer
        //        // Transition code for the transition from Normal to Overheated
        //    }
        //}
        //else if(currentState == ThermometerState.Overheated)
        //{
        //    //update timer
        //    //look at timer, if timer if more than 0.1f then set a to false
        //    // if timer is more than 3.0f then set to true, currentlevel 0, closemouth, switch to normal state
        //}

        if(currentLevel_ >= 0 && currentLevel_ <= 7)
        {
            sr_.sprite = allSprites_[currentLevel_];
        }
        else if (currentLevel_ > 7)
        {
            //if(!cooldown)
            //{
                sr_.sprite = allSprites_[8];
                StartCoroutine(CoolDown());
                //cooldown = true;
            //}
        }
    }
}
