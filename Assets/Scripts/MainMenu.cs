using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSettings.Instance.isGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Play()
    {
        SceneManager.LoadScene("Sample");
    }
}
