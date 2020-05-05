using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject TMPro_;
    private TextMeshProUGUI text_;

    private void Awake()
    {
        text_ = TMPro_.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text_.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text_.color = Color.white;
    }
}
