using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuUiController : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public SettingsMenuController settingsMenuUicontroller;
    public string gameSceneName="Sample";
    
    private void Start()
    {
        startButton.onClick.AddListener(StartNewGame);
        settingsButton.onClick.AddListener(SettingsMenuShow);
    }
    public void StartNewGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(gameSceneName);
        

    }
    public void SettingsMenuShow()
    {
        gameObject.SetActive(false);
    }
}
