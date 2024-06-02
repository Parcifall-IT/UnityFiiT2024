using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject button;

    void Update()
    {
        GetComponent<EdgeCollider2D>().isTrigger = !button.activeSelf;
    }
}
