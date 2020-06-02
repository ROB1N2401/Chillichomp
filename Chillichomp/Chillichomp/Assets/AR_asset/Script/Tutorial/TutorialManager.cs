using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    internal bool TutorialSpecialState1; //is set to true after reaching a certain stage of tutorial; it is used in FoodControl.cs in order to spawn only mild and medium food for the time being
    internal bool TutorialSpecialState2; //is set to true after reaching a certain stage of tutorial; it is used in FoodControl.cs in order to spawn only hot food for the time being
    internal int PlatesEaten;
    
    [SerializeField] private List<Sprite> _boxes = new List<Sprite>(); //list designated for storing all tutorial explanation texts
    [SerializeField] private List<GameObject> _arrows = new List<GameObject>(); //list for storing all arrows
    [SerializeField] private UnityEvent _boxEvent1 = null;
    [SerializeField] private UnityEvent _boxEvent2 = null;
    [SerializeField] private UnityEvent _boxEvent3 = null;
    [SerializeField] private UnityEvent _boxEvent4 = null;
    [SerializeField] private UnityEvent _boxEvent5 = null;
    [SerializeField] private GameObject _tutorialWindow = null;
    [SerializeField] private GameObject _headOutline = null;
    [SerializeField] private TutorialFoodControl _foodControlComponent = null;
    [SerializeField] private float _headOutlineShowcaseTime = 0f;
    private FoodMovement _foodMovementComponent = null;
    private Image _imageComponent = null;
    private int _currentBox = 0;
    private bool _isTrue = false; //boolean variable that indicates whether is the tutoral box enabled or disabled

    private void Awake()
    {
        PlatesEaten = 0;
        TutorialSpecialState1 = false;
        TutorialSpecialState2 = false;
        _foodControlComponent = GetComponent<TutorialFoodControl>();
        _foodControlComponent.enabled = false;
        _foodMovementComponent = FindObjectOfType<FoodMovement>();
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
            //Debug.Log("TutorialManager: current condition is 1");
        }
        else if (_currentBox == 2 && !_isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 2");
            //Debug.Log("Plates eaten: " + PlatesEaten);

            if (PlatesEaten >= 2)
            {
                _arrows[0].SetActive(false);
                _boxEvent3.Invoke();
                SwitchBool();
            }
        }
        else if (_currentBox == 2 && _isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 3");
            _foodControlComponent.enabled = false;
        }
        else if (_currentBox == 3 && !_isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 4");
            //Debug.Log("Plates eaten: " + PlatesEaten);
            
            if (PlatesEaten >= 4)
            {
                _arrows[1].SetActive(false);
                _foodControlComponent.enabled = false;
                _boxEvent4.Invoke();
                SwitchBool();
            }
        }
        else if (_currentBox == 3 && _isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 5");

        }
        else if (_currentBox == 4 && !_isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 6");
            WaterControl waterComponent = FindObjectOfType<WaterControl>();
            if (waterComponent.WaterAmount() < 3)
            {
                _arrows[2].SetActive(false);
                SwitchBool();
            }
        }
        else if (_currentBox == 5 && !_isTrue)
        {
            //Debug.Log("TutorialManager: current condition is 7"); 
            //_arrows[2].SetActive(false);
            _foodControlComponent.enabled = true;
            ThermometerControl thermometerControlComponent = FindObjectOfType<ThermometerControl>();
            if (thermometerControlComponent._level > 7)
            {
                _foodControlComponent.enabled = false;
                TutorialSpecialState2 = false;
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
            SceneManager.LoadScene("AR_prototype");
        }

        _currentBox += 1;
        _imageComponent.sprite = _boxes[_currentBox];

        if(_currentBox == 1)
        {
            TutorialSpecialState1 = true;
            GetComponent<TutorialFoodControl>().CreateFood();
            _boxEvent1.Invoke();
            _headOutline.SetActive(true);
            StartCoroutine(StartCountdown(_headOutlineShowcaseTime));
        }
        else if(_currentBox == 2)
        {
            _arrows[0].SetActive(true);
            _foodControlComponent.enabled = true;
        }
        else if (_currentBox == 3)
        {
            _arrows[1].SetActive(true);
            _foodControlComponent.enabled = true;
        }
        else if (_currentBox == 4)
        {
            _arrows[2].SetActive(true);

        }
        else if (_currentBox == 5)
        {
            TutorialSpecialState1 = false;
            TutorialSpecialState2 = true;
        }
    }

    IEnumerator StartCountdown(float delay)
    {
        yield return new WaitForSeconds(delay);

        _headOutline.SetActive(false);
        _boxEvent2.Invoke();
        SwitchBool();
    }

    public void EatOneDish()
    {
        PlatesEaten++;
    }
}
