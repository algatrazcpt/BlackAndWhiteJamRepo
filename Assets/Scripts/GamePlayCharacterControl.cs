using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCharacterControl : MonoBehaviour
{
    Animator animator;
    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private GameObject CurrentRituel;
    public Vector2 boxSize;
    public FriendlyMagicControl friendlyMagicControl;
    public DialogController dialogController;
    public bool rFail = true;
    public bool isShowTime=false;
    public float fireAnimationGet = 0.3f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         degisken();
        if(isShowTime&&rFail)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                dialogController.SpecialDialogGet(4f, dialogController.allDialogs[4]);
                rFail = false;
                friendlyMagicControl.Mission2();
            }
        }
        else if(!rFail&&isShowTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                if(rituelCast)
                {
                    AnimationPlay();
                    rituelCast = false;
                }
                else
                {
                    if (isMoveable)
                    {
                        dialogController.SpecialDialogGet(3f,dialogController.allDialogs[5]);
                    }

                }
            }


        }
        

    }
    public void PressRFail()
    {
        dialogController.CustomDialogGet(2);
    }


    void degisken()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0 | y != 0)
        {
            animator.SetFloat("speed", 1.5f);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
        moveDelta = new Vector3(x, y, 0);
        //swap right or left
        if (moveDelta.x > 0)
        {
            //transform.localScale = Vector3.one;
            transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
        }
        else if (moveDelta.x < 0)
        {
            //transform.localScale=new  Vector3(-1, 1,1);
            transform.localScale = new Vector3(-0.16f, 0.16f, 0.16f);
        }
        if (isMoveable)
        {
            transform.position += moveDelta * Time.deltaTime;
        }
    }


    void AnimationPlay()
    {
        animator.SetTrigger("MagicChargeT");
        Invoke("GetFire", fireAnimationGet);
        
    }
    void GetFire()
    {
        Instantiate(firendlyFire, transform.position, transform.rotation);
    }

    public bool isMoveable = true;
    private bool rituelRegion = true;
    public bool rituelPoint = true;
    public bool rituelCast = false;
    public GameObject firendlyFire;
    bool isShowAfter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Teleport1")
        {
            if (!isShowAfter)
            {
                dialogController.CustomDialogGet(0);
                friendlyMagicControl.isMission1 = true;
                isShowAfter = true;
            }
        }
        else if (collision.gameObject.CompareTag("RituelPoint"))
        {
            if (friendlyMagicControl.isOnetime[2] == false)
            {
                rituelCast = true;
                dialogController.SpecialDialogGet(2f, dialogController.allDialogs[6]);
            }
        }
    }
}
