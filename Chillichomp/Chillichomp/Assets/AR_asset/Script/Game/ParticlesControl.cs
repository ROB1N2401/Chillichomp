using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;

public class ParticlesControl : MonoBehaviour
{
    public GameObject HitRoofAnimation;
    // Start is called before the first frame update
    void Start()
    {
        HitRoofAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ThermometerControl>().CheckHitRoof())
        {
            HitRoofAnimation.SetActive(true);
        }
        else
        {
            HitRoofAnimation.SetActive(false);
        }
        HitRoofAnimation.transform.position =
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().HeadPose.position;

        HitRoofAnimation.transform.rotation = 
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().HeadPose.rotation;





    }
}
