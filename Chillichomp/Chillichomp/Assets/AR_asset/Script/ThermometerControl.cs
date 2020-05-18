using System.Collections;
using System.Collections.Generic;
using GoogleARCore.Examples.AugmentedFaces;
using UnityEngine;

public class ThermometerControl : MonoBehaviour
{
    private int _level;
    private float _timer;
    private SpriteRenderer _sr;
    [SerializeField] private List<Sprite> _allSprites; 
    //storing sprites of different states, where 0 is the lowest temperature and 3 is overheating

    private void Awake()
    {
        _level = 0;
        _timer = 0f;
        _sr = GetComponent<SpriteRenderer>();
        GetComponent<Transform>().position = new Vector3(2f, 3.8f, 8);
    }

    void Update()
    {
        _sr.sprite = _allSprites[_level];
        if(0 <= _level && _level <= 5)
        {
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().SetFaceFilterState(false);
        }
        else
        {
            GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().SetFaceFilterState(true);
        }
        if(_level > 7)
        {
            _timer += Time.deltaTime;
            if(_timer >= 7)
            {
                GameObject.Find("GameObjectControl").GetComponent<FaceFilterSwitch>().SetFaceFilterState(false);
                _timer = 0;
                _level = 3;
            }
        }
    }

    public void AddLevel(int a)
    {
        _level = _level + a;
        GameObject.Find("Audio Source").GetComponent<AudioControl>().IncreaseScore();
        if(_level>7)
        {
            GameObject.Find("Audio Source").GetComponent<AudioControl>().HitRoof();
            _level = 8;
        }
        else if(_level>5)
        {
            GameObject.Find("Audio Source").GetComponent<AudioControl>().Warn();
        }
    }

    public void LoseLevel(int a)
    {
        _level = _level - a;
        if(_level < 0)
        {
            _level = 0;
        }
        _timer = 0;
    }

    public bool CheckHitRoof()
    {
        if(_level>7)
        {
            return true;
        }
        return false;
    }
}
