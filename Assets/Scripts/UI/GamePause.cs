using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static bool IsPaused {  get; private set; }
    private static List<IPauseHendler> paused = new List<IPauseHendler>();

    public static void SetPause(bool isEnable)
    {
        IsPaused = isEnable;

        for (var i = 0; i < paused.Count; i++)
        {
            paused[i].IsPaused(isEnable);
        }
    }

    public static void Add(IPauseHendler p)
    {
        paused.Add(p);
    }

    public static void Remove(IPauseHendler p)
    {
        paused.Remove(p);
    }
}

public interface IPauseHendler
{
    void IsPaused(bool isPaused);
}