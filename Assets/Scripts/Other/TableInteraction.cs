using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;

    private void OnMouseDown()
    {
        shopCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
