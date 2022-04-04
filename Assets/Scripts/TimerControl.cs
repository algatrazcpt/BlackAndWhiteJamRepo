using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
public class TimerControl : MonoBehaviour
{
    public Sprite[] timeState;
    public GameObject timeGameObjcet;
    public Animator particleAnimator;
    public float stateCallTime=5f;
    float minute = 0;
    float hours = 0;
    int currentStateCount = 0;
    int stateCount = 0;
    void Start()
    {

        timeGameObjcet.GetComponent<Image>().sprite = timeState[currentStateCount];
        InvokeRepeating("TimeCounting", 0, stateCallTime);
        stateCount=timeState.Length;
    }
    void TimeCounting()
    {
        if (minute>59)
        {

            minute = 0;
            hours += 1;
        }
        else
        {
            minute += 1;

            PlayeParticle();
        }
    }
    public void TimeStateChanger()
    {
        currentStateCount++;
        if (currentStateCount >= stateCount)
        {
            timeGameObjcet.GetComponent<Animator>().enabled = true;
            timeGameObjcet.GetComponent<Animator>().SetTrigger("Crash");
            Debug.Log("Time Finished");
            currentStateCount = 0;
            Destroy(gameObject);
        }
        timeGameObjcet.GetComponent<Image>().sprite = timeState[currentStateCount];
        Debug.Log("TimeStateChange");
    }
    public void PlayeParticle()
    {
        particleAnimator.SetTrigger("ParticleT");
    }
    

}
