using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEfectControl : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomAnimation", 0,Random.Range(0f, 15.5f));
    }
    void RandomAnimation()
    {
        animator.SetTrigger("RandomT");
    }

}
