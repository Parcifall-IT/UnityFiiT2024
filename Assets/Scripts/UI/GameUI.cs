using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private GameObject player;

    private int choosedWeapon;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        choosedWeapon = player.GetComponent<PlayerAttack>().choosedWeapon;
        text.text = choosedWeapon == 0 ? "bow" : "sword";
    }
}
