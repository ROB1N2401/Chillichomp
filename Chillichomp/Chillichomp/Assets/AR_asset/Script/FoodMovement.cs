using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class FoodMovement : MonoBehaviour
{
    //[SerializeField] private List<Sprite> allSprites_;
    private float _timer = 0;

    public int Spiciness;
    public int Score;
    internal int PlatesEaten = 0;

    void Start()
    {
        transform.position = new Vector3(0, _timer - 7, 9);
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        transform.position = new Vector3(0, _timer - 6, 8 + _timer * 1.3f);

        if (transform.position.y > -3)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineMouth())
            {
                _timer = 0;

                GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().IncreaseScore(Score);
                GameObject.Find("Thermomter").GetComponent<ThermometerControl>().AddLevel(Spiciness);
                GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();

                TutorialManager tutorialManagerComponent = FindObjectOfType<TutorialManager>();
                tutorialManagerComponent.PlatesEaten++;

                Destroy(this.gameObject);
            }
        }
        if (transform.position.y > -1.7f)
        {
            _timer = 0;
            GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();
            Destroy(this.gameObject);
        }
    }
    //void Update()
    //{
    //    _timer += Time.deltaTime;
    //    transform.position = new Vector3(0, _timer - 6, 8 + _timer * 1.3f);

    //    if (transform.position.y > -3.5)
    //    {
    //        if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineMouth())
    //        {
    //            _timer = 0;

    //            GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().IncreaseScore(Score);
    //            GameObject.Find("Thermomter").GetComponent<ThermometerControl>().AddLevel(Spiciness);
    //            GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();

    //            Destroy(this.gameObject);
    //        }
    //    }
    //    if (transform.position.y > 0.2f)
    //    {
    //        _timer = 0;
    //        GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();
    //        Destroy(this.gameObject);
    //    }
    //}
}