using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMagicControl : MonoBehaviour
{
    public GamePlayCharacterControl playerObject;
    public Collider2D teleport;
    DialogController dialogController;
    public bool isMainMission = true;
    public bool isMission1 = false;
    public bool isMission2 = false;
    public bool isMission3 = false;
    public bool isMission4 = false;
    public bool isMission5 = false;
    public bool isDialogStart = false;
    public int currentMissionId = 0;
    public bool[] isOnetime = new bool[10];
    void Start()
    {
        for (int a = 0; a < isOnetime.Length; a++)
        {
            isOnetime[a] = true;
        }


        dialogController = GetComponent<DialogController>();
        teleport.enabled = false;
    }
    private void FixedUpdate()
    {
        isMainMission = isMainMission != dialogController.isMissionState;

    }
    public IEnumerator playerMoveControl(bool value)
    {
        playerObject.isMoveable = value;
        yield return null;
    }
    public void ColliderActiviteController(bool value)
    {
        gameObject.GetComponent<Collider2D>().enabled = value;
    }


    private  void OnCollisionEnter2D(Collision2D collision)
    {
        isDialogStart = true;
        if (isMainMission)
        {
            ColliderActiviteController(false);
            dialogController.MultiDialogGet(0,5);
            StartCoroutine(playerMoveControl(false));
            isMainMission= false;
            teleport.enabled = true;
        }   
        else
        {
            switch(currentMissionId)
            {
                case 0:
                    {
                        if(isMission1)
                        {
                            isMission1 = true;
                            dialogController.CustomDialogGet(5);
                            playerObject.isShowTime = true;
                            playerObject.PressRFail();
                            currentMissionId = 1;
                        }
                        else
                        {

                            dialogController.CustomDialogGet(7);
                        }
                        break;
                    }
                case 1:
                    {
                        if (isMission2)
                        {
                            isMission2 = true;
                           // dialogController.CustomDialogGet(5);
                            playerObject.isShowTime = true;
                        }
                        else if (playerObject.rFail&&!isOnetime[2])
                        {
                            playerObject.isShowTime = true;
                            playerObject.PressRFail();
                            
                            
                        }
                        else
                        {
                            if (isOnetime[2])
                            {
                                playerObject.PressRFail();
                                //Mission2();
                            }
                            else
                            {
                                dialogController.CustomDialogGet(12);
                            }
                        }

                            break;
                    }
            }
            
           
        }
        
    }
    public void Mission2()
    {
        ColliderActiviteController(false);
        Debug.Log("Mission2");
        StartCoroutine(playerMoveControl(false));
        dialogController.MultiDialogGet(8, 11);
        isOnetime[2] = false;
    }
}
