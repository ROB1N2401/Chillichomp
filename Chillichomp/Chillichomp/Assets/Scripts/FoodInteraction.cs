using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodInteraction : MonoBehaviour
{ 
    [SerializeField] private GameObject head_;
    [SerializeField] private GameObject scoreHolder_;
    [SerializeField] private GameObject multiplierHolder_;
    [SerializeField] private GameObject statsHolder_;
    [SerializeField] private List<Sprite> allSprites_; //0 for "mouth closed", 1 for "mouth open", 2 for "chewing" and 3 for "struggling"
    [SerializeField] private KeyCode key_;

    private SpriteRenderer sr_;
    private int score_;
    private int multiplier_;
    internal bool inZone_;

    public void IncreaseScore()
    {
        TextMeshProUGUI scoreText = scoreHolder_.GetComponent<TextMeshProUGUI>();
        score_ = score_ + (1 * multiplier_);
        scoreText.text = "Score: " + score_.ToString();
    }

    public void IncreaseMultiplier()
    {
        Debug.Log("Multiplier before: " + multiplier_);
        TextMeshProUGUI multiplierText = multiplierHolder_.GetComponent<TextMeshProUGUI>();
        multiplier_ ++;
        multiplierText.text = "X" + multiplier_.ToString();
        Debug.Log("Multiplier after: " + multiplier_);
    }

    public void NullifyMultiplier()
    {
        TextMeshProUGUI multiplierText = multiplierHolder_.GetComponent<TextMeshProUGUI>();
        multiplier_ = 1;
        multiplierText.text = "X" + multiplier_.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        score_ = 0;
        multiplier_ = 1;
        sr_ = head_.GetComponent<SpriteRenderer>();
        inZone_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key_) && !inZone_)
        {
            OpenMouth();
            NullifyMultiplier();
            Invoke("CloseMouth", 0.5f);
        }

        //if(Input.GetKeyDown(KeyCode.X))
        //{
        //    Debug.Log("X");
        //}
    }

    private void CloseMouth()
    {
        sr_.sprite = allSprites_[0];
    }

    private void OpenMouth()
    {
        sr_.sprite = allSprites_[1];
    }

    private void Chew()
    {
        sr_.sprite = allSprites_[2];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("FoodInZone");
        if ((collision.gameObject.tag == "Food"))
        {
            inZone_ = true;
        }

        if ((collision.gameObject.tag == "Food") && (Input.GetKeyDown(key_) || Input.GetKeyUp(key_)))
        {
            OpenMouth();
            Invoke("Chew", 0.2f);
            Invoke("CloseMouth", 1f);

            IncreaseScore();
            IncreaseMultiplier();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone_ = false;
    }
}
