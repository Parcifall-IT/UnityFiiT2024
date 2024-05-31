using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameObject player;


    [SerializeField] private Image Q;
    [SerializeField] private Image E;

    [SerializeField] private Image distance;
    [SerializeField] private Image melee;

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

    public void ChangeDistance(Sprite sprite)
    {
        distance.sprite = sprite;
    }

    public void ChangeMelee(Sprite sprite)
    {
        melee.sprite = sprite;
    }
}
