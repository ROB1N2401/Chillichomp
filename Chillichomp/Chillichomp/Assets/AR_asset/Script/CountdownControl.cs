using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class CountdownControl : MonoBehaviour
{
    public float StartingTime;
    //public string SceneName;
    public TextMeshProUGUI Text;
    public GameObject Victory;

    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _countdown;
    [SerializeField] private List<Sprite> _number;
    private float _timer = 0;
    private int _currentImage;
    private bool _instantiateVictoryCondition = true;
    private bool _countdownAtBegin = true;

    void Start()
    {
        Text.text = StartingTime.ToString();
        _currentImage = 0;
        _timer = 0;
        _countdown.GetComponent<Image>().sprite = _number[_currentImage];
        _endMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _countdown.gameObject.SetActive(_countdownAtBegin);
        _timer += Time.deltaTime;
        if (_countdownAtBegin)
        {
            _startCountdown();
        }
        else
        {
            if (StartingTime > 0)
            {
                StartingTime -= Time.deltaTime;
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
            }
        }
    }

    IEnumerator RestartGame(GameObject Text)
    {
        yield return new WaitForSeconds(4.5f);
        Destroy(Text);
        Time.timeScale = 0f;
        _endMenu.gameObject.SetActive(true);
    }

    private void _startCountdown()
    {
        if(_timer>=0)
        {
            if (_currentImage == 3)
            {
                _countdown.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
            else 
            {
                _countdown.transform.localScale -= new Vector3(0.06f, 0.06f, 0);
            }
        }

        if(_countdown.transform.localScale.x<=5.5 && _timer>=0.3f)
        {
            StartCoroutine(ChangeNumber());
            _timer = -0.3f;
        }       
        if(_currentImage==4)
            {
                _countdownAtBegin = false;
                GameObject.Find("GameObjectControl").GetComponent<FoodControl>().CreateFood();
                return;
            }
    }

    IEnumerator ChangeNumber()
    {
        yield return new WaitForSeconds(0.3f);
        _currentImage++;
        _countdown.GetComponent<Image>().sprite = _number[_currentImage];
        _countdown.transform.localScale = new Vector3(8, 8, 1);
    }
}
