using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTips : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("activeTips", true);
    }

    public void Show()
    {
        Debug.Log("zaza");
        animator.SetBool("activeTips", true);
    }

    public void Vanish()
    {
        animator.SetBool("activeTips", false);
    }
}
