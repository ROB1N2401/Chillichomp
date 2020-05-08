using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;

public class ThermometerControl : MonoBehaviour
{

    private int level = 0;
    private float timer = 0;
    [SerializeField] private List<Sprite> Thermometer_sprite;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(2f,3.8f,8);
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 7)
        {
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().Open_face_filter(true);
            timer += Time.deltaTime;
            if (timer >= 7)
            {
                GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().Open_face_filter(false);
                timer = 0;
                level = 0;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Thermometer_sprite[level];
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
