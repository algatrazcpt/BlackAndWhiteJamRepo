using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimeController : MonoBehaviour
{
    public float fireShowtime = 5f;
    void Start()
    {
        Invoke("FireDelete", fireShowtime);
    }
    void FireDelete()
    {
        Destroy(gameObject);
    }
}
