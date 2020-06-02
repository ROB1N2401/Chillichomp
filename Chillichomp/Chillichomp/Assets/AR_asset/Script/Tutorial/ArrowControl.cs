using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControl : MonoBehaviour
{
    [SerializeField] private List<Sprite> _arrow;
    public float interval = 0;


    private float timer = 0;
    private int current_Arrow;

    private void Start()
    {
        timer = 0;
        current_Arrow = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        int filter_number = _arrow.Count;
        if (timer >= interval)
        {
            timer = 0;
            GetComponent<Image>().sprite = _arrow[current_Arrow];
            current_Arrow++;
            if (current_Arrow == filter_number)
            {
                current_Arrow = 0;
            }
        }
    }
}
