using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    private GameSettings gameSettings;
    private AudioSource audioSource;
    // Update is called once per frame
    private void Start()
    {
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        audioSource=gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSource.volume = gameSettings.Volume;
    }
}
