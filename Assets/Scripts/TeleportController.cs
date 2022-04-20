using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    Animator animator;
    public GameObject ConnectTeleport;
    Vector3 teleportLocation;
    public float teleportDelay = 3f;
    public bool isTeleportCoolDown=false;
    GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        teleportLocation=ConnectTeleport.transform.position;
    }
    void TeleportLocation()
    {
        
        if (isTeleportCoolDown == false)
        {
            player.transform.position = teleportLocation;
            ConnectTeleport.GetComponent<TeleportController>().TeleportStart();
            TeleportStart();

        }
    }
    public void TeleportStart()
    {
        isTeleportCoolDown = true;
        animator.SetBool("TeleportCoolDownB", true);
        Invoke("TeleportDelay",teleportDelay);
    }
    // Update is called once per frame
    void TeleportDelay()
    {
        animator.SetBool("TeleportCoolDownB", false);
        isTeleportCoolDown = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TeleportLocation();
    }
}
