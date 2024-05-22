using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TableOutlineEffect : MonoBehaviour
{
    [SerializeField] private GameObject outline;

    void Start()
    {
        if (outline != null)
        {
            outline.SetActive(false);
        }
    }

    void OnMouseEnter()
    {
        if (outline != null)
        {
            outline.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (outline != null)
        {
            outline.SetActive(false);
        }
    }
}