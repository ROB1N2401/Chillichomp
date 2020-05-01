using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class FoodControl : MonoBehaviour
{
    //Food prefab 
    public GameObject miduim_f;
    public GameObject middle_f;
    public GameObject strong_f;

    private bool create = true;


    private void Update()
    {
        GameObject[] Prefab = new GameObject[3] { middle_f, middle_f, strong_f };

        float r = Random.Range(0, 2.99f);
        int R = (int)r;

        if (create)
        {
            Instantiate(Prefab[R]);
            print("233333"+r);
            create = false;
        }
    }
    public void create_food()
    {
        create = true;
    }

}