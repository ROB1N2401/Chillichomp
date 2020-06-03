using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QueueControl : MonoBehaviour
{
    [SerializeField] private List<Sprite> _point;

    [SerializeField] private Image _first;
    [SerializeField] private Image _second;
    [SerializeField] private Image _third;
 

    void Update()
    {
        _first.sprite = _point[GetComponent<FoodControl>().FoodOrder[0]];
        _second.sprite = _point[GetComponent<FoodControl>().FoodOrder[1]];
        _third.sprite = _point[GetComponent<FoodControl>().FoodOrder[2]];
    }
}
