using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
public class TimerControl : MonoBehaviour
{
    public Sprite[] timeState;
    public GameObject timeGameObjcet;
    public Animator particleAnimator;
    public Animator playerAnimator;
    private float stateCallTime=10F;
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
        Debug.Log("TimeCount"+minute);
        minute += 1;
            PlayeParticle();
        TimeStateChanger();
    }
    public void TimeStateChanger()
    {
        currentStateCount++;
        Debug.Log(currentStateCount);
        if (currentStateCount > stateCount-1)
        {
            timeGameObjcet.GetComponent<Animator>().enabled = true;
            timeGameObjcet.GetComponent<Animator>().SetTrigger("Crash");
            Debug.Log("Time Finished");

            GameOver();
            currentStateCount = 0;
        }
        timeGameObjcet.GetComponent<Image>().sprite = timeState[currentStateCount];
        Debug.Log("TimeStateChange");
    }
    public void PlayeParticle()
    {
        particleAnimator.SetTrigger("ParticleT");
    }
    public void GameOver()
    {
        playerAnimator.SetTrigger("PlayerDeathT");
        GameSaveSystem.SaveGame(Random.Range(3,5));
        Invoke("LoadScene", 1f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }
    

}
