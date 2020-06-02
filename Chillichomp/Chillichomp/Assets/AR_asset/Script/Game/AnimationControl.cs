using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private List<Material> _filter;
    public Material FrenzyFilter;
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
        int filter_number = _filter.Count;
        if(timer >= interval)
        {
            timer = 0;
            GameObject.Find("FaceTexture").GetComponent<MeshRenderer>().material = _filter[current_filter];
            current_filter++;
            if(current_filter==filter_number)
            {
                current_filter = 0;
            }
        }
        if (GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().CheckHitRoof())
        {
            GameObject.Find("FaceTexture").GetComponent<MeshRenderer>().material = FrenzyFilter;
        }
    }
}
