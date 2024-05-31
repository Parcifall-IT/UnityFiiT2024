using UnityEngine;
using TMPro;

public class Arbalest: MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private int arrowCounter;
    [SerializeField] private TMP_Text counter;

    private void Start()
    {
        arrowCounter = 5;
    }

    public void Shoot()
    {
        if (arrowCounter > 0)
        {
            Instantiate(arrow, GetComponent<Transform>().position, Quaternion.identity);
            arrowCounter--;
        }

        UpdateCounterUI();
    }

    public int GetArrows()
    {
        return arrowCounter;
    }

    public void AddArrows()
    {
        arrowCounter++;
        UpdateCounterUI();
    }

    private void UpdateCounterUI()
    {
        counter.text = arrowCounter.ToString();
    }

    public void SetArrow(Sprite newArrow)
    {
        arrow.GetComponent<SpriteRenderer>().sprite = newArrow;
    }

    public GameObject GetArrow()
    {
        return arrow;
    }
}
