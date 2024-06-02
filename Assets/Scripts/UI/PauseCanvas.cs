﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private bool isOpened = false; //Открыто ли меню
    [SerializeField] private float volume = 0; //Громкость
    [SerializeField] private int quality = 0; //Качество
    [SerializeField] private bool isFullscreen = false; //Полноэкранный режим
    [SerializeField] private AudioMixer audioMixer; //Регулятор громкости
    [SerializeField] private Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

    [SerializeField] private GameObject playerPlay;
    [SerializeField] private GameObject playerPause;

    [SerializeField] private GameObject defaultButton;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    public void ShowHideMenu()
    {
        GamePause.SetPause(!isOpened);
        Time.timeScale = isOpened ? 1 : 0;

        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;

        playerPlay.SetActive(!isOpened);
        playerPause.SetActive(isOpened);

        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
    }

    public void Exit()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
