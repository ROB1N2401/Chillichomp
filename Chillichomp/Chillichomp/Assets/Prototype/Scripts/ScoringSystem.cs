using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    internal int score_;
    internal int multiplier_;

    //[SerializeField] private GameObject scoreHolder_;
    //[SerializeField] private GameObject multiplierHolder_;

    //private TextMeshProUGUI scoreHolder_;
    //private TextMeshProUGUI multiplierHolder_;

    public void IncreaseScore(GameObject score_in)
    {
        TextMeshProUGUI scoreHolder_ = score_in.GetComponent<TextMeshProUGUI>();
        score_ = score_ + (1 * multiplier_);
        scoreHolder_.text = score_.ToString();
    }

    public void IncreaseMultiplier(GameObject multiplier_in)
    {
        TextMeshProUGUI multiplierHolder_ = multiplier_in.GetComponent<TextMeshProUGUI>();
        multiplier_ += 1;
        multiplierHolder_.text = "X" + multiplier_.ToString();
    }

    public void NullifyMultiplier(GameObject multiplier_in)
    {
        TextMeshProUGUI multiplierHolder_ = multiplier_in.GetComponent<TextMeshProUGUI>();
        multiplier_ = 1;
        multiplierHolder_.text = "X" + multiplier_.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        score_ = 0;
        multiplier_ = 1;
    }
}
