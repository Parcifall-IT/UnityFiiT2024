using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text;
    private TMP_Text text1;
    private Color old;
    public Color neww;

    void Start()
    {
        text1 = text.GetComponent<TMP_Text>();
        old = text1.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text1.color = neww;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text1.color = old;
    }
}
