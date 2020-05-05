using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFood : MonoBehaviour 
{
    internal bool shouldDeploy_;

    public GameObject[] food_;
    [SerializeField] private GameObject spawnPos_;
    [SerializeField] private float respawnMinTime_;
    [SerializeField] private float respawnMaxTime_;

    // Start is called before the first frame update
    void Start()
    {
        shouldDeploy_ = true;
        StartCoroutine(FoodWave());
    }

    private void SpawnFood()
    {
        int x = Random.Range(0, food_.Length);        
        GameObject a = Instantiate(food_[x]) as GameObject;
        a.transform.position = spawnPos_.transform.position;
        a.name = "Food_clone";

        FoodInteraction c = FindObjectOfType<FoodInteraction>();
        c.inZone_ = false;
    }

    public void DisableSpawn()
    {
        shouldDeploy_ = false;
    }

    IEnumerator FoodWave()
    {
        while (shouldDeploy_)
        {
            SpawnFood();
            yield return new WaitForSeconds(Random.Range(respawnMinTime_, respawnMaxTime_));
        }
    }
}
