using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] [TextArea] private List<string> _text = new List<string>(); //list designated for storing all tutorial explanation texts
    [SerializeField] private TextMeshProUGUI _tutorialTextTMP = null;
    [SerializeField] private TextMeshProUGUI _buttonTextTMP = null;
    private int _currentText = 0;

    private void Awake()
    { 
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
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
