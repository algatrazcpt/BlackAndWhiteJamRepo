using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RituelLightController : MonoBehaviour
{
    public GameObject[] rituellights;
    public bool isRituelLight = true;
    private void Start()
    {
        if (isRituelLight == false)
        {
            for (int currentLight = 0; currentLight < rituellights.Length; currentLight++)
            {
                rituellights[currentLight].GetComponent<Animator>().SetBool("LightB", true);
            }
        }
    }
    public void RituelLighting(bool value)
    {
        for(int currentLight=0;currentLight<rituellights.Length;currentLight++)
        {
            rituellights[currentLight].GetComponent<Animator>().SetBool("LightB", value);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRituelLight)
        {


            RituelLighting(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isRituelLight)
        {


            RituelLighting(false);
        }
    }
}
