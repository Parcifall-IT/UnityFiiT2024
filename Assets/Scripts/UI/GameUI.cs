using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameObject player;


    [SerializeField] private Image Q;
    [SerializeField] private Image E;

    private int choosedWeapon;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        choosedWeapon = player.GetComponent<PlayerAttack>().choosedWeapon;

        if (choosedWeapon == 0)
        {
            Q.gameObject.SetActive(true);
            E.gameObject.SetActive(false);
        }

        if (choosedWeapon == 1)
        {
            Q.gameObject.SetActive(false);
            E.gameObject.SetActive(true);
        }
    }
}
