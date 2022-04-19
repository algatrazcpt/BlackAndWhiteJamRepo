using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator animator;
    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private GameObject CurrentRituel;
    public Vector2 boxSize;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        degisken();
        if(rituelPoint&rituelCast==false)
        {
            rituelCast = true;
            rituelPoint = false;
            animator.SetTrigger("MagicChargeT");
            RituelRegionDelete(CurrentRituel);
        }
         if (Input.GetKeyDown(KeyCode.R)&rituelCast==true)
        {
            rituelCast = false;
            FrindlyGet();
        }

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
        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y* Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        hit = Physics2D.BoxCast(transform.position, boxSize, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        }
        else
        {
            if (hit.collider.CompareTag("RituelPoint"))
            {
                animator.SetTrigger("MagicChargeT");
                Debug.Log(hit.collider.gameObject.tag);
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
                rituelPoint = true;
                CurrentRituel = hit.collider.gameObject;
            }
            else if (!hit.collider.CompareTag("WallTag"))
            {
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
                rituelPoint = false;
                Debug.Log(hit.collider.gameObject.tag);
            }
        }

        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        hit = Physics2D.BoxCast(transform.position, boxSize, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null )
        {
            //Move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        else
        {
            if (hit.collider.CompareTag("RituelPoint"))
            {
                animator.SetTrigger("MagicChargeT");
                Debug.Log(hit.collider.gameObject.tag);
                //Move
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
                rituelPoint = true;
                CurrentRituel = hit.collider.gameObject;
            }
            else if(!hit.collider.CompareTag("WallTag"))
            {
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
                rituelPoint = false;
                Debug.Log(hit.collider.gameObject.tag);
            }
        }
    }




   
    void RituelRegion(bool value)
    {
        rituelRegion = value;
    }
    void RituelRegionDelete(GameObject v)
    {
        Destroy(v);
    }
    void RituelCast(bool value)
    {
        rituelCast=value;
    }
    void Method2()
    {
        if (rituelCast == true)
        {
            FrindlyGet();
            RituelCast(false);
        }
    }
    void Method1()
    {
        if(rituelRegion)
        {
            RituelRegion(true);
            RituelCast(true);
        }
    }
    void FrindlyGet()
    {
        animator.SetTrigger("MagicChargeT");
        new WaitForSeconds(0.030f);
        Instantiate(firendlyFire, transform.position, transform.rotation);
    }

    private bool rituelRegion = true;
    public bool rituelPoint = true;
    public bool rituelCast = false;
    public GameObject firendlyFire;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision" + collision.gameObject.name);
    }
}
