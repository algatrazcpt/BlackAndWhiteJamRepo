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

        settingsMenuUicontroller = SettingsMenuController.Instance;
        SettingsMenuController.Instance.mainMenuUi = gameObject;
        startButton.onClick.AddListener(StartNewGame);
        settingsButton.onClick.AddListener(SettingsMenuShow);
    }
    public void StartNewGame()
    {
        settingsMenuUicontroller.isMainMenuScene = false;
        settingsMenuUicontroller.SettingsMenuShow();
        gameObject.SetActive(false);
        SceneManager.LoadScene(gameSceneName);
        

    }
    public void SettingsMenuShow()
    {
        settingsMenuUicontroller.isMainMenuScene = true;
        settingsMenuUicontroller.SettingsMenuShow();
        gameObject.SetActive(false);
    }
}
