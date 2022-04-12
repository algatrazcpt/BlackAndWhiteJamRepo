using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControl : MonoBehaviour
{
    public bool rituelRegion= true;
    public bool rituelPoint = true;
    public bool rituelCast = true;
    public GameObject firendlyFire;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rituelPoint)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //animator.SetTrigger("MagicChargeT");
                FrindlyGet();
            }
        }
    }
    void FrindlyGet()
    {
        animator.SetTrigger("MagicChargeT");
        new WaitForSeconds(0.030f);
        Instantiate(firendlyFire,transform.position,transform.rotation);
    }
}
