using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreControl : MonoBehaviour
{
    public Text ScoreText;

    private int _score;

    private void Awake()
    {
        _score = 0;
        ScoreText.transform.position = new Vector3(540, 1950, 0);
    }

    void Update()
    {
        ScoreText.text = _score.ToString();
    }

    public void IncreaseScore(int scoreIn)
    {
        _score += scoreIn;
    }
}