using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] [TextArea (14, 10)] private List<string> _text = new List<string>(); //list designated for storing all tutorial explanation texts
    [SerializeField] private TextMeshProUGUI _tutorialTextTMP = null;
    [SerializeField] private TextMeshProUGUI _buttonTextTMP = null;
    [SerializeField] private Image _imageComponent = null;
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    private int _currentText = 0;

    private void Awake()
    {
        _buttonTextTMP.text = "Next";

        if (_text != null)
        {
            _tutorialTextTMP.text = _text[_currentText];
        }
        else
            Debug.LogError("TutorialConrol.cs: text list is empty");
    }

    public void CallNext()
    {
        _currentText += 1;

        if (_currentText == _text.Count - 1)
        {
            _buttonTextTMP.text = "Close";
        }

        if (_currentText <= _text.Count - 1)
        {
            _tutorialTextTMP.text = _text[_currentText];
        }
        else
        {
            _currentText = 0;
            _buttonTextTMP.text = "Next";
            _tutorialTextTMP.text = _text[0];
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
    //public void Update()
    //{
    //    print("check"+_currentText);
    //    if(_currentText==0)
    //    {
    //        print(_text[0]);
    //    }
    //}
}
