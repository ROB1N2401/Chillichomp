using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRevealEffect : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI = null;
    private char[] _letters = { };

    public float RevealTime;
    [TextArea] public string Text;
 
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _letters = Text.ToCharArray();
        StartCoroutine(SpawnText());
    }

    IEnumerator SpawnText()
    {
        // ?? gameObject.AddComponent<TextMeshPro>();
        for (int i = 0; i < _letters.Length; i++)
        {
            _textMeshProUGUI.text += _letters[i];
            yield return new WaitForSeconds(RevealTime);
        }
    }
}
