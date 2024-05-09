using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCameraBase[] virtualCameras;
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
        foreach (var camera in virtualCameras)
        {
            camera.gameObject.SetActive(false);
        }
        currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

        virtualCameras[currentCameraIndex].gameObject.SetActive(true);
    }
}