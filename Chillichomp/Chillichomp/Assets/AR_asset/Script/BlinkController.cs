using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkController : MonoBehaviour
{
    [SerializeField] private float _blinkingInterval = 0f;
    private Image _imageComponent = null;
    private float _currentTime = 0f;
    private float _nextReadyTime = 0f;

    private void Awake()
    {
        _nextReadyTime = _blinkingInterval;
        _imageComponent = GetComponent<Image>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _nextReadyTime)
        {
            _nextReadyTime += _blinkingInterval;
            _imageComponent.enabled = !_imageComponent.enabled;
        }
    }
}
