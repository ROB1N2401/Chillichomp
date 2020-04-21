using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFood : MonoBehaviour 
{ 
    public GameObject food_;
    [SerializeField] private GameObject spawnPos_;
    [SerializeField] private float respawnMinTime_;
    [SerializeField] private float respawnMaxTime_;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FoodWave());
    }

    private void SpawnFood()
    {
        GameObject a = Instantiate(food_) as GameObject;
        a.transform.position = spawnPos_.transform.position;
        a.name = "Food_clone";

        FoodInteraction c = FindObjectOfType<FoodInteraction>();
        c.inZone_ = false;
    }

    IEnumerator FoodWave()
    {
        while (true)
        {
            SpawnFood();
            yield return new WaitForSeconds(Random.Range(respawnMinTime_, respawnMaxTime_));
        }
    }
}
