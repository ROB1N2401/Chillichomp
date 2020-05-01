using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class FoodMovement : MonoBehaviour
{
    private float timer = 0;
    private int c = 0;
    //Food prefab 

    private void Start()
    {
        transform.position = new Vector3(0, timer - 7, 9);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(0, timer-6, 8+timer*0.9f);

        //if(timer>6)
        //{
        //    timer = 0;
        //    Switch.GetComponent<FoodControl>().create_food();
        //    Destroy(this.gameObject);
        //}

        //if (Switch.GetComponent<FaceFilterSwitch>().determine_mouth())
        //{
        //    timer = 0;
        //    Switch.GetComponent<FoodControl>().timer = 5;
        //    transform.position = new Vector3(0, -6, 8);
        //    Switch.GetComponent<ScoreControl>().Get_score(5);
        //    Destroy(this.gameObject);
        //}
        if (transform.position.y > -3.5)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().determine_mouth())
            {
                timer = 0;
                if (this.gameObject.tag == "medium_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(1);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(1);
                }
                else if (this.gameObject.tag == "middle_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(3);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(3);
                }
                else if (this.gameObject.tag == "strong_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(10);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(7);
                }
                GameObject.Find("GameObjectControl").GetComponent<FoodControl>().create_food();
                Destroy(this.gameObject);
            }
        }
        if (transform.position.y > 0.5f)
        {
            timer = 0;
            GameObject.Find("GameObjectControl").GetComponent<FoodControl>().create_food();
            Destroy(this.gameObject);
        }
    }
}