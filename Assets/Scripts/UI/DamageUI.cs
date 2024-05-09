using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    public static DamageUI Instance { get; private set; }

    private class ActiveText
    {
        public TMP_Text UIText;
        public float maxTime;
        public float Timer;
        public Vector2 unitPosition;
        public Vector2 direction;

        public void MoveText(Camera camera)
        {
            var delta = 1f - (Timer / maxTime);
            var pos = unitPosition + new Vector2(delta, delta) * direction;

            UIText.transform.position = pos;
        }
    }

    [SerializeField] private TMP_Text TextPrefab;
    const int PoolSize = 64;

    Queue<TMP_Text> TextPool = new Queue<TMP_Text>();
    List<ActiveText> ActiveTexts = new List<ActiveText>();

    private void Awake()
    {
        Instance = this;
    }

    Camera camera;
    Transform Transform;

    void Start()
    {
        camera = Camera.main;
        Transform = transform;

        for (var i = 0; i < PoolSize; i++)
        {
            var temp = Instantiate(TextPrefab, transform);
            temp.gameObject.SetActive(false);
            TextPool.Enqueue(temp);
        }
    }

    private void Update()
    {
        for (var i = 0; i < ActiveTexts.Count; i++)
        {
            var at = ActiveTexts[i];
            at.Timer -= Time.deltaTime;

            if (at.Timer < 0f)
            {
                at.UIText.gameObject.SetActive(false);
                TextPool.Enqueue(at.UIText);
                ActiveTexts.RemoveAt(i);
                --i;
            }
            else
            {
                var color = at.UIText.color;
                color.a = at.Timer / at.maxTime;
                at.UIText.color = color;

                at.MoveText(camera);
            }
        }
    }

    public void AddText(int amount, Vector2 unitPos)
    {
        var t = TextPool.Dequeue();
        t.text = amount.ToString();
        t.gameObject.SetActive(true);

        var at = new ActiveText() { maxTime = 1f, direction = new Vector2(Random.Range(-1f, 1f), 1.5f) };
        at.Timer = at.maxTime;
        at.UIText = t;
        at.unitPosition = unitPos + Vector2.up * 1.5f;

        at.MoveText(camera);
        ActiveTexts.Add(at);
    }
}
