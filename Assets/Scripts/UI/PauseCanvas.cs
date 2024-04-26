using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private bool isOpened = false; //Открыто ли меню
    [SerializeField] private int isStopped = 1; //Остановлено ли время
    [SerializeField] private float volume = 0; //Громкость
    [SerializeField] private int quality = 0; //Качество
    [SerializeField] private bool isFullscreen = false; //Полноэкранный режим
    [SerializeField] private AudioMixer audioMixer; //Регулятор громкости
    [SerializeField] private Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    public void ShowHideMenu()
    {
        isStopped = (isStopped + 1) % 2;
        Time.timeScale = isStopped;

        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
    }
}
