using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
public class TimerControl : MonoBehaviour
{
    public Sprite[] timeState;
    public Animator timeAnimator;
    public Animator particleAnimator;
    public float animtionPlayOfSet=3f;
    float minute = 0;
    float hours = 0;
    int currentStateCount = 0;
    int stateCount = 0;
    void Start()
    {

        gameObject.GetComponent<Image>().sprite = timeState[0];
        InvokeRepeating("TimeCounting", 0, 5);
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
            TimeStateChanger();
        }
    }
    public void TimeStateChanger()
    {
        currentStateCount++;
        if (currentStateCount >= stateCount)
        {
            currentStateCount = 0;
        }
        PlayeParticle();
        new WaitForSeconds(animtionPlayOfSet);
        gameObject.GetComponent<Image>().sprite = timeState[currentStateCount];
    }
    public void PlayeParticle()
    {
        particleAnimator.SetTrigger("ParticleT");
    }

}
