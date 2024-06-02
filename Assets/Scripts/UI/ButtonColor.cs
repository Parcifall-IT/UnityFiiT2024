using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject text;
    private TMP_Text text1;
    private Color old;
    [SerializeField] private Color neww;

    void Start()
    {
        text1 = text.GetComponent<TMP_Text>();
        old = text1.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text1.color = neww;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text1.color = old;
    }

    public void OnSelect(BaseEventData eventData)
    {
        text1.color = neww;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text1.color = old;
    }
}
