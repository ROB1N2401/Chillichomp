using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreControl : MonoBehaviour
{
    public Text scoreText;
    private int score;

    private void Awake()
    {
        score = 0;
        scoreText.transform.position = new Vector3(540, 1950, 0);
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int score_in)
    {
        score += score_in;
    }
}