using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    public float arrowLifeTime = 10f;
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Invoke("DeleteObject", arrowLifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
                GameSaveSystem.SaveGame(5);
                //collision.gameObject.GetComponent<PlayerAllControls>().PlayerDeath();
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            DeleteObject();
        }
    }
    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
