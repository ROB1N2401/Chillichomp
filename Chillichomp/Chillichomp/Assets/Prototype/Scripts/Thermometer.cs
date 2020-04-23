using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
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
    }


    // Update is called once per frame
    void Update()
    {
        if(currentLevel_ >= 0 && currentLevel_ <= 7)
        {
            sr_.sprite = allSprites_[currentLevel_];
        }
        else if (currentLevel_ > 7)
        {
            sr_.sprite = allSprites_[8];
            StartCoroutine(CoolDown());
        }
    }
}
