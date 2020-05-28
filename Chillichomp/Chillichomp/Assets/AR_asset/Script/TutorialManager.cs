using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    internal bool TutorialSpecialState; //is set to true after reaching a certain stage of true; it is used in FoodControl.cs in order to spawn only hot food for the time being
    
    [SerializeField] private List<Sprite> _boxes = new List<Sprite>(); //list designated for storing all tutorial explanation texts
    [SerializeField] private List<GameObject> _arrows = new List<GameObject>(); //list for storing all arrows
    [SerializeField] private GameObject _tutorialWindow = null;
    [SerializeField] private GameObject _headOutline = null;
    [SerializeField] private float _headOutlineShowcaseTime = 0f;
    private Image _imageComponent = null;
    private int _currentBox = 0;
    private bool _isTrue = false; //boolean variable that indicates whether is the tutoral box enabled or disabled

    private void Awake()
    {
        TutorialSpecialState = false;
        _imageComponent = _tutorialWindow.GetComponent<Image>();
        _imageComponent.sprite = _boxes[_currentBox];
    }

    private void Start()
    {
        Invoke("SwitchBool", 0.3f);
    }

    private void Update()
    {
        _tutorialWindow.SetActive(_isTrue);

        if (_currentBox == 1 && _isTrue)
        {
            Debug.Log("TutorialManager: current condition is 1");
            _arrows[0].SetActive(true);
        }
        else if (_currentBox == 2 && !_isTrue)
        {
            Debug.Log("TutorialManager: current condition is 2");
            FoodMovement foodMovementComponent = FindObjectOfType<FoodMovement>();
            Debug.Log("Plates eaten: " + foodMovementComponent.PlatesEaten);
            if (foodMovementComponent.PlatesEaten >= 2)
            {
                SwitchBool();
            }
        }
        else if (_currentBox == 2 && _isTrue)
        {
            Debug.Log("TutorialManager: current condition is 3");
            _arrows[1].SetActive(true);
        }
        else if (_currentBox == 3 && !_isTrue)
        {
            Debug.Log("TutorialManager: current condition is 4");
            FoodMovement foodMovementComponent = FindObjectOfType<FoodMovement>();
            if (foodMovementComponent.PlatesEaten >= 4)
            {
                SwitchBool();
            }
        }
        else if (_currentBox == 3 && _isTrue)
        {
            Debug.Log("TutorialManager: current condition is 5");
            _arrows[2].SetActive(true);
        }
        else if (_currentBox == 4 && !_isTrue)
        {
            Debug.Log("TutorialManager: current condition is 6");
            Water waterComponent = FindObjectOfType<Water>();
            if (waterComponent.glassAmount_ < 3)
            {
                SwitchBool();
            }
        }
        else if (_currentBox == 5 && !_isTrue)
        {

            Debug.Log("TutorialManager: current condition is 7"); 
            ThermometerControl thermometerControlComponent = FindObjectOfType<ThermometerControl>();
            if (thermometerControlComponent._level > 7)
            {
                TutorialSpecialState = false;
                SwitchBool();
            }
        }

    }

    private void SwitchBool()
    {
        _isTrue = !_isTrue;
    }

    public void SwitchBox()
    {
        SwitchBool();

        if(_currentBox == 5)
        {
            SceneManager.LoadScene("MainMenu");
        }

        _currentBox += 1;
        _imageComponent.sprite = _boxes[_currentBox];

        if(_currentBox == 1)
        {
            _headOutline.SetActive(true);

            StartCoroutine(StartCountdown(_headOutlineShowcaseTime));
        }
        else if(_currentBox == 2)
        {
            _arrows[0].SetActive(false);
        }
        else if (_currentBox == 3)
        {
            _arrows[1].SetActive(false);
        }
        else if (_currentBox == 4)
        {
            _arrows[2].SetActive(false);
        }
        else if (_currentBox == 5)
        {
            TutorialSpecialState = true;
        }
    }

    IEnumerator StartCountdown(float delay)
    {
        yield return new WaitForSeconds(delay);

        _headOutline.SetActive(false);
        SwitchBool();
    }
}
