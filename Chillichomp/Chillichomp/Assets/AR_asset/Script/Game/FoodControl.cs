using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    //private QueueSystem _queueSystemComponent = null;
    private int[] _foodCreateRate;
    private bool create = false;

    public int[] FoodOrder;

    private void Awake()
    {
        //_queueSystemComponent = FindObjectOfType<QueueSystem>();
        _foodCreateRate = new int[_foodPrefabs.Count];
        FoodOrder = new int[3];
        _foodCreateRate[0] = _midFoodRate;
        _foodCreateRate[1] = _medFoodRate;
        _foodCreateRate[2] = _strongFoodRate;
        for (int a = 0; a > 2; a++)
        {
            FoodOrder[a] = RandomNumber(_foodCreateRate);
        }
    }

    private void Update()
    {
        if (create)
        {
            print("Order " + FoodOrder[0]);
            Instantiate(_foodPrefabs[FoodOrder[0]]);
            //Instantiate(_foodPrefabs[_queueSystemComponent.Dishes[0]]);
            {
                FoodOrder[0] = FoodOrder[1];
                FoodOrder[1] = FoodOrder[2];
                FoodOrder[2] = RandomNumber(_foodCreateRate);
            }
            print("Orders " + FoodOrder);
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