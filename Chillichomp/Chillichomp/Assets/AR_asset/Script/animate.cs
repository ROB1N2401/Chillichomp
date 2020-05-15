using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class animate : MonoBehaviour
{
    [SerializeField] private List<Material> Filter;
    public float interval = 0;


    private float timer = 0;
    private int current_filter;

    private void Start()
    {
        timer = 0;
        current_filter = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        int filter_number = Filter.Count;
        if(timer >= interval)
        {
            timer = 0;
            GameObject.Find("FaceTexture").GetComponent<MeshRenderer>().material = Filter[current_filter];
            print("running" + current_filter);
            current_filter++;
            if(current_filter==filter_number)
            {
                current_filter = 0;
            }
        }
    }
}
