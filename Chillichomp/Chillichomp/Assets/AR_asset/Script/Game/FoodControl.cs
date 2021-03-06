﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class FoodControl : MonoBehaviour
{
    //Food prefab 
    [SerializeField] private List<GameObject> _foodPrefabs;
    [SerializeField] private int _midFoodRate;
    [SerializeField] private int _medFoodRate;
    [SerializeField] private int _strongFoodRate;

    private int[] _foodCreateRate;
    private bool create = false;

    private void Start()
    {
        _foodCreateRate = new int[_foodPrefabs.Count];
        _foodCreateRate[0] = _midFoodRate;
        _foodCreateRate[1] = _medFoodRate;
        _foodCreateRate[2] = _strongFoodRate;
    }

    private void Update()
    {
        if (create)
        {
            Instantiate(_foodPrefabs[RandomNumber(_foodCreateRate)]);
            //Instantiate(_foodPrefabs[Random.Range(0,2)]);
            create = false;
        }
    }

    public void CreateFood()
    {
        create = true;
    }

    public int RandomNumber(int[] _foodCreateRate)
    {
        int randomRate = Random.Range(1, 101);
        int currentRate = 0;
        for (int currentNumber = 0; currentNumber < _foodCreateRate.Length; currentNumber++)
        {
            currentRate += _foodCreateRate[currentNumber];
            if (randomRate < currentRate)
            {
                return currentNumber;
            }
        }
        return 0;
    }
}