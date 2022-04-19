using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMagicControl : MonoBehaviour
{
    DialogController dialogController;
    public bool isMainMission = true;
    bool isMission1=false;
    bool isMission2 = false;
    bool isMission3 = false;
    bool isMission4 = false;
    bool isMission5 = false;
    private void Start()
    {
        dialogController = GetComponent<DialogController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HElpme");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HELLLLPPPP");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        if (isMainMission)
        {
            var v=dialogController.MultiDialogGet(0,4);

            collision.gameObject.GetComponent<GamePlayCharacterControl>().isMoveable = false;
            isMainMission = false;
            if(v==true)
            {
                Debug.Log("Animasyon bitti");
            }
        }   
        else
        {
            if (isMission1)
            {
                isMission2 = true;
            }
            else
            {

            }
        }
    }
}
