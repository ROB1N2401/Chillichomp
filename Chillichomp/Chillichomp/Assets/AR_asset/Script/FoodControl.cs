using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class FoodControl : MonoBehaviour
{
    //Food prefab 
    [SerializeField] private List<GameObject> foodPrefabs_;

    private bool create = true;
    private void Update()
    {
        int R = Random.Range(0, foodPrefabs_.Count);
        
        if (create)
        {
            Instantiate(foodPrefabs_[R]);
            create = false;
        }
    }


    public void CreateFood()
    {
        create = true;
    }

}