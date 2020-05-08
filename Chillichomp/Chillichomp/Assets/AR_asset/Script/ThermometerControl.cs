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
        transform.position = new Vector3(2f, 3.8f, 8);
    }
    private int level;
    private float timer;
    private SpriteRenderer sr_;
    [SerializeField] private List<Sprite> allSprites_; 
    //storing sprites of different states, where 0 is the lowest temperature and 3 is overheating

    private void Awake()
    {
        level = 0;
        timer = 0f;
        sr_ = GetComponent<SpriteRenderer>();
        GetComponent<Transform>().position = new Vector3(2f, 3.8f, 8);

    }

    void Update()
    {

        if (level == 7)

        if(0 <= level && level <= 7)
        {
            sr_.sprite = allSprites_[level];
        }
        if(level>7)

        {
            sr_.sprite = allSprites_[7];
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().SetFaceFilterState(true);
            timer += Time.deltaTime;

            if (timer >= 7)

            if(timer >= 7)

            {
                GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().SetFaceFilterState(false);
                timer = 0;
                level = 0;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Thermometer_sprite[level];
    }

    public void AddLevel(int a)
    {
        level = level + a;
    }

    public void LoseLevel(int a)
    {
        level = level - a;
        if(level < 0)
        {
            level = 0;
        }
    }

}
