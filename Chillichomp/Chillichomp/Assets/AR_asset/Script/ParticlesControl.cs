using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;

public class ParticlesControl : MonoBehaviour
{
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a.transform.position=
            new Vector3(GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().HeadPose.position.x,
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().HeadPose.position.y,7);
        a.transform.rotation=
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().HeadPose.rotation;

        
    }
}
