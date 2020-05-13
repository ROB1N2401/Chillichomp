using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class FoodControl : MonoBehaviour
{
    //Food prefab 
    [SerializeField] private List<GameObject> _foodPrefabs;

    private bool create = true;
    private void Update()
    {
        int r = Random.Range(0, _foodPrefabs.Count);
        
        if (create)
        {
            Instantiate(_foodPrefabs[r]);
            create = false;
        }
    }


    public void CreateFood()
    {
        create = true;
    }

}