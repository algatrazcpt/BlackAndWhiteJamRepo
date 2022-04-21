using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2Controller : MonoBehaviour
{

    Transform arrowTrapPoint;
    Animator animator;
    public GameObject arrow;
    private void Start()
    {
        arrowTrapPoint = gameObject.GetComponentInParent<Transform>();
        animator = gameObject.GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var v=Instantiate(arrow, arrowTrapPoint.position, arrowTrapPoint.rotation);
            if (transform.rotation.z <= -90 && transform.rotation.z <= 0)
            {
                v.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
            }
            else if(transform.rotation.z > -90 && transform.rotation.z <= -180)
            {
                v.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            }
            else if (transform.rotation.z > -180 && transform.rotation.z <= -270)
            {
                v.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
            }
            else
            {
                v.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
            }

        }

    }
}
