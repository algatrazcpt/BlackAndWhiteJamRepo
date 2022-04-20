using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RituelLightController : MonoBehaviour
{
    public GameObject[] rituellights;
    public void RituelLighting(bool value)
    {
        for(int currentLight=0;currentLight<rituellights.Length;currentLight++)
        {
            rituellights[currentLight].GetComponent<Animator>().SetBool("LightB", value);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        RituelLighting(true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        RituelLighting(false);
    }
}
