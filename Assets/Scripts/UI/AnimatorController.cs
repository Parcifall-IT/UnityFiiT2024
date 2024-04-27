using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour, IPauseHendler
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void IsPaused(bool isPaused)
    {
        animator.enabled = !isPaused;
    }

    private void OnEnable()
    {
        GamePause.Add(this);
    }

    private void OnDisable()
    {
        //GamePause.Remove(this);
    }
}
