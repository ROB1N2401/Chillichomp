using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  _scoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreRext;
    private int _score;

    private void Awake()
    {
        _score = 0;
        _scoreText.transform.position = new Vector3(540, 1950, 0);
    }

    void Update()
    {
        _scoreText.text = _score.ToString();
        _finalScoreRext.text= _score.ToString();
    }

    public void IncreaseScore(int scoreIn)
    {
        _score += scoreIn;
        GameObject.Find("Audio Source").GetComponent<AudioControl>().EatFood();
    }
}