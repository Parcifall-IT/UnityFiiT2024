using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseCanvas : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню
    public int isStopped = 1; //Остановлено ли время
    public float volume = 0; //Громкость
    public int quality = 0; //Качество
    public bool isFullscreen = false; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
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
