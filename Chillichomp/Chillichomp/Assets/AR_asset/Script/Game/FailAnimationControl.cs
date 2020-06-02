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
        this.transform.position = new Vector3(0, -2.3f, 9);
        GameObject.Find("Audio Source").GetComponent<AudioControl>().DropOut();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=0.85f)
        {
            Destroy(this.gameObject);
        }
    }
}
