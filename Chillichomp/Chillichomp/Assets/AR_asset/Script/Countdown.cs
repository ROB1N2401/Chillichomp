using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;


public class Countdown : MonoBehaviour
{
    public float StartingTime;
    public string SceneName;
    //public TextMeshProUGUI Text;
    public GameObject Victory;

    [SerializeField] private UnityEvent _disableControls;
    private bool _instantiateVictoryCondition = true;

    // Update is called once per frame
    void Update()
    {
        if (StartingTime > 0)
        {
            StartingTime -= Time.deltaTime;
            //Debug.Log(startingTime_);
        }

        //Text.text = Mathf.Round(StartingTime).ToString();

        if (StartingTime <= 0)
        {
            if (_instantiateVictoryCondition == true)
            { 
                GameObject f = Instantiate(Victory) as GameObject;
                f.transform.position = Camera.main.transform.position;
                GameObject.Find("Audio Source").GetComponent<AudioControl>().Final();
                _instantiateVictoryCondition = false;
            }

            _disableControls.Invoke();

            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        //yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneName);
    }
}
