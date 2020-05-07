//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Thermometer : MonoBehaviour
//{
//    internal int currentLevel_; //spiciness level
//    internal bool isActive_;

//    [SerializeField] private List<Sprite> allSprites_; //storing sprites of different states, where 0 is the lowest temperature and 3 is overheating
//    [SerializeField] private float overheatTime_;
//    private SpriteRenderer sr_;


//    void Awake()
//    {
//        sr_ = GetComponent<SpriteRenderer>();
//        currentLevel_ = 0;
//        isActive_ = false;
//    }

//    public void IncreaseTemperature(int spiciness_in)
//    {
//        currentLevel_ += spiciness_in;
//    }

//    public void DecreaseTemperature(int spiciness_in)
//    {
//        currentLevel_ -= spiciness_in;
//    }

//    IEnumerator CoolDown()
//    {
//        FoodInteraction a = FindObjectOfType<FoodInteraction>();
//        DeployFood b = FindObjectOfType<DeployFood>();

//        sr_.sprite = allSprites_[8];
//        isActive_ = true;
//        a.Overheat();

//        yield return new WaitForSeconds(0.2f);

//        a.enabled = false;
//        b.enabled = false;

//        yield return new WaitForSeconds(overheatTime_);

//        a.enabled = true;
//        b.enabled = true;
//        a.CloseMouth();

//        currentLevel_ = 0;
//        isActive_ = false;
//    }

//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Q))
//        {
//            IncreaseTemperature(1);
//        }
//        if (currentLevel_ >= 0 && currentLevel_ <= 7)
//        {
//            sr_.sprite = allSprites_[currentLevel_];
//        }
//        else if (currentLevel_ > 7 && !isActive_)
//        {
//            StartCoroutine(CoolDown());
//        }
//    }
//}