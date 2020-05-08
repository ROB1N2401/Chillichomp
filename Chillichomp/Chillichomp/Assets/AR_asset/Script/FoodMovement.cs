using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class FoodMovement : MonoBehaviour
{
    //[SerializeField] private List<Sprite> allSprites_;
    private float timer_ = 0;

    public int spiciness_;
    public int score_;

    void Start()
    {
        transform.position = new Vector3(0, timer_ - 7, 9);
    }

    void Update()
    {
        timer_ += Time.deltaTime;
        transform.position = new Vector3(0, timer_ - 6, 8 + timer_ * 1.3f);

        if (transform.position.y > -3.5)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineMouth())
            {
                timer_ = 0;

                GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().IncreaseScore(score_);
                GameObject.Find("Thermomter").GetComponent<ThermometerControl>().AddLevel(spiciness_);
                GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();

                Destroy(this.gameObject);
            }
        }
        if (transform.position.y > 0.5f)
        {
            timer_ = 0;
            GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();
            Destroy(this.gameObject);
        }
    }
}