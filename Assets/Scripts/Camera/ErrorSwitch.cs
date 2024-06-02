using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCameraBase[] virtualCameras;
    private int currentCameraIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        virtualCameras[0].gameObject.SetActive(false);

        virtualCameras[1].gameObject.SetActive(true);
    }
}
