using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class FoodMovement : MonoBehaviour
{
    [SerializeField] private float _foodSpeed;
    [SerializeField] private int _spiciness;
    [SerializeField] private int _score;
    [SerializeField] private List<GameObject> _failAnimation;
    private float _timer = 0;


    void Start()
    {
        transform.position = new Vector3(0, _timer - 7, 9);
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        transform.position = new Vector3(0, _timer*_foodSpeed - 6, 8 + _timer * 1.3f);

        if (transform.position.y > -3.5f)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineMouth())
            {
                _timer = 0;

                GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().IncreaseScore(_score);
                GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().AddLevel(_spiciness);
                GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();

                Destroy(this.gameObject);
            }
        }
        if (transform.position.y > -2.25f)
        {
            _timer = 0;
            if(gameObject.tag=="medium_f")
            {
                _failAnimation[0].transform.position = new Vector3(0, -2F, 6.5f);
                Instantiate(_failAnimation[0]);
            }
            if (gameObject.tag == "middle_f")
            {
                _failAnimation[1].transform.position = new Vector3(0, -2F, 6.5f);
                Instantiate(_failAnimation[1]);
            }
            if (gameObject.tag == "strong_f")
            {
                _failAnimation[2].transform.position = new Vector3(0, -2F, 6.5f);
                Instantiate(_failAnimation[2]);
            }
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