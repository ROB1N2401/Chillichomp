using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Main camera
    [SerializeField] private Camera _camera;
    //How long a shock lasts
    [SerializeField] private float _shakeTime = 1.5f;
    //How often shakes camera
    [SerializeField] private float _currentTime=0.8f;
    //Control shake
    private bool _shakeAble;
    private float _timer;

    private void Start()
    {
        _timer = 0;
    }

    private void FixedUpdate()
    {
        if(_shakeAble)
        {
            _shakeCamera();
        }
    }

    private void _shakeCamera()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.8)
        {
            _currentTime = _shakeTime;
            _timer = 0;
        }

        if (_currentTime > 0.0f)
        {
            _currentTime -= Time.deltaTime;
            _camera.rect = new Rect(0.04f * (-1.0f + 2.0f * Random.value) * Mathf.Pow(_currentTime, 2),
                0.04f * (-1.0f + 2.0f * Random.value) * Mathf.Pow(_currentTime, 2), 1.0f, 1.0f);
        }
        else
        {
            _currentTime = 0.0f;
        }
    }

    public bool ControlShake(bool a)
    {
        return a;
    }
}
