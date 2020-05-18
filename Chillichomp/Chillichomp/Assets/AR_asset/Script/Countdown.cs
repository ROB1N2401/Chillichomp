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
    public TextMeshProUGUI Text;
    public GameObject Victory;

    [SerializeField] private GameObject _EndMenu;
    [SerializeField] private UnityEvent _disableControls;
    private bool _instantiateVictoryCondition = true;

    void Start()
    {
        Text.text = StartingTime.ToString();
        _EndMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartingTime > 0)
        {
            StartingTime -= Time.deltaTime;
            //Debug.Log(startingTime_);
        }

        Text.text = Mathf.Round(StartingTime).ToString();

        if (StartingTime <= 0)
        {
            if (_instantiateVictoryCondition == true)
            { 
                GameObject f = Instantiate(Victory) as GameObject;
                f.transform.position = Camera.main.transform.position;
                GameObject.Find("Audio Source").GetComponent<AudioControl>().Final();
                _instantiateVictoryCondition = false;
                StartCoroutine(RestartGame(f));
            }

            //_disableControls.Invoke();

        }
    }

    IEnumerator RestartGame(GameObject Text)
    {
        yield return new WaitForSeconds(4f);
        Destroy(Text);
        Time.timeScale = 0f;
        _EndMenu.gameObject.SetActive(true);
    }
}
