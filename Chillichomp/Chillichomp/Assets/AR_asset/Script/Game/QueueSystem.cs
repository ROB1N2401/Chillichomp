using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    internal List<int> Dishes; //list of three upcoming types of food

    [SerializeField] private int _midFoodRate;
    [SerializeField] private int _medFoodRate;
    [SerializeField] private int _strongFoodRate;
    [SerializeField] private List<GameObject> _icons = null; //list of icon prefabs. 0 - single, 1 - two, 2 - maximum 
    [SerializeField] private List<Transform> _queueBoxes = null; //list of transform positions of 3 windows within queue. The 0 index is the upcoming type of food 
    private int[] _foodCreateRate;

    void Awake()
    {
        _foodCreateRate = new int[3];
        _foodCreateRate[0] = _midFoodRate;
        _foodCreateRate[1] = _medFoodRate;
        _foodCreateRate[2] = _strongFoodRate;
    }

    void Start()
    {
        while (Dishes.Count < 3)
        {
            Dishes.Add(RandomNumber(_foodCreateRate));
        }

        for (int i = 0; i < Dishes.Count; i++)
        {
            GameObject a = Instantiate(_icons[Dishes[i]]) as GameObject;
            a.transform.position = _queueBoxes[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshQueue()
    {
        Dishes.RemoveAt(0);
        Dishes.Add(RandomNumber(_foodCreateRate));

        GameObject[] remainingIcons = GameObject.FindGameObjectsWithTag("SpicinessIcon");
        foreach(var remainingIcon in remainingIcons)
        {
            Destroy(remainingIcon);
        }

        if (Dishes.Count == 3)
        {
            for (int i = 0; i < Dishes.Count; i++)
            {
                GameObject a = Instantiate(_icons[Dishes[i]]) as GameObject;
                a.transform.position = _queueBoxes[i].position;
            }
        }
        else Debug.LogError("QueueSystem.cs, RefreshQueue() method: there is not enough dishes in the list.");
    }

    public int RandomNumber(int[] _foodCreateRate)
    {
        int randomRate = Random.Range(1, 101);
        int currentRate = 0;
        for (int currentNumber = 0; currentNumber < _foodCreateRate.Length; currentNumber++)
        {
            currentRate += _foodCreateRate[currentNumber];
            if (randomRate < currentRate)
            {
                return currentNumber;
            }
        }
        return 0;
    }
}
