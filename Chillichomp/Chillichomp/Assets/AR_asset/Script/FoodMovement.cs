using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;
using UnityEngine.UI;
public class FoodMovement : MonoBehaviour
{
    private float timer = 0;
    private int c = 0;
    //value
    public int medium_f_score = 1;
    public int medium_f_pungency = 1;

    public int middle_f_score = 3;
    public int middle_f_pungency = 3;

    public int strong_f_score = 10;
    public int strong_f_pungency = 7;

    private void Start()
    {
        transform.position = new Vector3(0, timer - 7, 9);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(0, timer-6, 8+timer*1.2f);

        if (transform.position.y > -3.5)
        {
            if (GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().determine_mouth())
            {
                timer = 0;
                if (this.gameObject.tag == "medium_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(medium_f_score);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(medium_f_pungency);
                }
                else if (this.gameObject.tag == "middle_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(middle_f_score);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(middle_f_pungency);
                }
                else if (this.gameObject.tag == "strong_f")
                {
                    GameObject.Find("GameObjectControl").GetComponent<ScoreControl>().Get_score(strong_f_score);
                    GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().add_level(strong_f_pungency);
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