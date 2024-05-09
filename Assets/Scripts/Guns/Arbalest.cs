using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbalest: MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    public void Shoot()
    {
        Instantiate(arrow, GetComponent<Transform>().position, Quaternion.identity);
    }
}
