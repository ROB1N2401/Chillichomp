using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] [TextArea (14, 10)] private List<string> _text = new List<string>(); //list designated for storing all tutorial explanation texts
    [SerializeField] private GameObject _imageShowcase = null;
    [SerializeField] private TextMeshProUGUI _tutorialTextTMP = null;
    [SerializeField] private TextMeshProUGUI _buttonTextTMP = null;
    [SerializeField] private Image _imageComponent = null;
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    private int _currentText = 0;
    private bool _showImage = false;

    private void Awake()
    {
        _buttonTextTMP.text = "Next";

        _imageShowcase.SetActive(false);

        if (_text != null)
        {
            _tutorialTextTMP.text = _text[_currentText];
        }
        else
            Debug.LogError("TutorialConrol.cs: text list is empty");
    }

    private void Update()
    {
        _imageShowcase.SetActive(_showImage);
    }

    public void CallNext()
    {
        _showImage = false;
        _currentText += 1;

        if (_currentText == _text.Count - 1)
        {
            _buttonTextTMP.text = "Close";
        }

        if (_currentText == 2)
        {
            _showImage = true;
            _imageComponent.sprite = _sprites[0];
        }
        else if (_currentText == 3)
        {
            _showImage = true;
            _imageComponent.sprite = _sprites[1];
        }
        else if (_currentText == 4)
        {
            _showImage = true;
            _imageComponent.sprite = _sprites[2];
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
