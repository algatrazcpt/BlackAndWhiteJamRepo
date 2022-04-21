using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1Controller : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Trap1T");
        if (collision.CompareTag("Player"))
        {
            GameSaveSystem.SaveGame(2);
            collision.gameObject.GetComponent<PlayerAllControls>().PlayerDeath();
        }
        else
        {

        }
    }
}
