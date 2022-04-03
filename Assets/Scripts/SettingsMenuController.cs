using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsMenuController : MonoBehaviour
{
    private GameSettings gameSettings=GameSettings.Instance;
    public Button exitMenuButton;
    public Slider volumeSlider;
    private float volume;
    private string activeSceneName;
    private string mainMenuSceneName = "MainMenu2";
    private string gameMenuSceneName = "Sample";
    void Start()
    {
        gameSettings.isSettingsOneOpen = false;
        exitMenuButton.onClick.AddListener(MainMenuReturn);
        volume= gameSettings.Volume;
        volumeSlider.value = gameSettings.Volume;
        volumeSlider.onValueChanged.AddListener(VolumeSet);
        if (gameSettings.isGame)
        {
            exitMenuButton.GetComponentInChildren<Text>().text = "Return Game";
            activeSceneName = gameMenuSceneName;
        }
        else
        {
            exitMenuButton.GetComponentInChildren<Text>().text = "Return Main Menu";
            activeSceneName = mainMenuSceneName;
        }
    }
    void VolumeSet(float value)
    {
        volume = value;
        gameSettings.Volume = value;
    }
    public float VolumeGet()
    {
        return volume;
    }

    public void MainMenuReturn()
    {
        
        if(gameSettings.isGame)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(gameMenuSceneName));
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Setting"));
            gameSettings.isSettingsOneOpen = true;
            gameSettings.TimeControl(false);

        }
        else
        {
            SceneManager.LoadScene(activeSceneName);
            gameSettings.isSettingsOneOpen = true;
        }
    }
}
