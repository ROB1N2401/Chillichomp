using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;

public class ThermometerControl : MonoBehaviour
{
    public GameObject Thermometer;
    private int level = 0;
    private float timer = 0;
    GameObject[] list = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        list[0] = GameObject.Find("Thermometer0");
        list[1] = GameObject.Find("Thermometer1");
        list[2] = GameObject.Find("Thermometer2");
        list[3] = GameObject.Find("Thermometer3");
        list[4] = GameObject.Find("Thermometer4");
        list[5] = GameObject.Find("Thermometer5");
        list[6] = GameObject.Find("Thermometer6");
        list[7] = GameObject.Find("Thermometer7");
        for(int a=0;a<8;a++)
        {
            list[a].SetActive(false);
            list[a].transform.position= new Vector3(2f,3.8f,8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            for (int a = 0; a < 8; a++)
            {
                list[a].SetActive(false);
            }
            list[level].SetActive(true);
        }
        if(level==7)
        {
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().Open_face_filter(true);
            timer += Time.deltaTime;
            if(timer>=7)
            {
                GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().Open_face_filter(false);
                timer = 0;
                level = 0;
            }
        }
    }

    public void add_level(int a)
    {
        level = level + a;
        if(level>7)
        {
            level = 7;
        }
    }

    public void lose_level(int a)
    {
        level = level - a;
        if(level<0)
        {
            level = 0;
        }
    }

}
