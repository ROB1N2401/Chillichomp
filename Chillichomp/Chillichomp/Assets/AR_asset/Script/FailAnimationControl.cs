using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailAnimationControl : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=0.9f)
        {
            Destroy(this.gameObject);
        }
    }
}
