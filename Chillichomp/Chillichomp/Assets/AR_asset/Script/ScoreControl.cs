using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreControl : MonoBehaviour
{
    public GameObject Score_text;
    private int Score = 0;

    void Start()
    {
        Score = 0;
        Score_text.transform.position = new Vector3(540, 1950, 0);
    }


    void Update()
    {
        Score_text.GetComponent<Text>().text = Score.ToString();
    }

    public void Get_score(int score)
    {
        for(; score>0; score--)
        {
            Score++;
        }
    }
}