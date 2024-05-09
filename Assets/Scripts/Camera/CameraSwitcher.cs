using System;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera nextCamera;

    private bool isInside;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isInside)
            {
                isInside = false;
                return;
            }
            isInside = true;
            nextCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            nextCamera.gameObject.SetActive(false);
            isInside = false;
        }
    }
}