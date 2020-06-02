using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class TutorialFoodMovement : MonoBehaviour
{
    [SerializeField] private int _spiciness;
    [SerializeField] private int _score;

    private float _speed;
    [SerializeField] private GameObject _failAnimation;

    private float _timer = 0;
    internal int PlatesEaten = 0;

    void Start()
    {
        transform.position = new Vector3(0, _timer - 7, 9);
        _speed = 1.2f;
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        transform.position = new Vector3(0, _timer*_speed - 6, 8 + _timer * 1.3f);

        if (transform.position.y > -3.5)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().DetermineMouth())
            {
                _timer = 0;

                GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().IncreaseScore(_score);
                GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().AddLevel(_spiciness);
                GameObject.Find("GameObjectControl").GetComponent<TutorialFoodControl>().CreateFood();
                GameObject.Find("GameObjectControl").GetComponent<TutorialManager>().EatOneDish();
                Destroy(this.gameObject);
            }
        }
        if (transform.position.y > -2.3f)
        {
            _timer = 0;
            GameObject.Find("GameObjectControl").GetComponent<TutorialFoodControl>().CreateFood();
            Instantiate(_failAnimation);
            Destroy(this.gameObject);
        }
    }
}