using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControl : MonoBehaviour
{
    public bool rituelRegion= true;
    public bool rituelPoint = true;
    public bool rituelCast = false;
    public GameObject firendlyFire;
    public Animator animator;
    private GameObject rituelCollider;

    // Update is called once per frame
    void Update()
    {
            if (rituelPoint & rituelCast == false)
            {
                animator.SetTrigger("MagicChargeT");
                rituelCast = true;
                rituelPoint = false;
                Debug.Log(rituelCollider);
            }

             if (rituelCast == true&& Input.GetKeyDown(KeyCode.R))
            {
                FrindlyGet();
                rituelCast = false;

            }
        
    }

    void FrindlyGet()
    {
        animator.SetTrigger("MagicChargeT");
        new WaitForSeconds(0.030f);
        Instantiate(firendlyFire,transform.position,transform.rotation);
    }


}
