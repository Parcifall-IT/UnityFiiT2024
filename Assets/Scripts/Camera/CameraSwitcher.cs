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
            nextCamera.Priority = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isInside)
        {
            nextCamera.Priority = 0;
            isInside = false;
        }
    }
}