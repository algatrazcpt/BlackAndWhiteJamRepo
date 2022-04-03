using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform point;
    public GameObject bullet;
    public float speed = 10f;
    public int startAmmo = 100;
    public int ClipSize = 10;
    public float ReloadSpeed = 3;
    public int currentAmmo;
    public int inMag;
    private float timer = 0.0f;
    public bool reloading;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = startAmmo;
        inMag = ClipSize;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            
        }


        if (reloading)
        {
            if(timer < ReloadSpeed)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0.0f;
            }

            if(timer >= ReloadSpeed)
            {
                currentAmmo += -ClipSize + inMag;
                inMag = ClipSize;
                timer = 0.0f;
                reloading = false;
            }
        }


        if (reloading == false)
        {


            if (Input.GetButtonDown("Fire1"))
            {
                if (inMag > 0)

                {
                    Shoot();
                }
                else
                {
                    Reload();
                }


            }
        }
    }

    void Reload()
    {
        
        reloading = true;
    }

    void Shoot()
    {
        inMag --;
        GameObject Bullets = Instantiate(bullet, point.position, point.rotation);
        Rigidbody2D rb = Bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(point.up * speed, ForceMode2D.Impulse);
        Destroy(Bullets, 3.0f);
    }
}
