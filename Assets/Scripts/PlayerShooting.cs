using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform point;
    public GameObject bullet;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject rbref = Instantiate(bullet, point.position, point.rotation);
        Rigidbody2D rb = rbref.GetComponent<Rigidbody2D>();
        rb.AddForce(point.up * speed, ForceMode2D.Impulse);
    }
}
