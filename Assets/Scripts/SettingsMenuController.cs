using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsMenuController : MonoBehaviour
{
    private GameSettings gameSettings=GameSettings.Instance;
    public Button exitMenuButton;
    public Image exitMenuButtonImage;
    public Slider volumeSlider;
    public Animator volumeBarAnimator;
    public Sprite[] menuSprite;
    private float volume;
    private string activeSceneName;
    private string mainMenuSceneName = "MainMenu2";
    private string gameMenuSceneName = "Level";
    void Start()
    {
        gameSettings.isSettingsOneOpen = false;
        //change scene
        exitMenuButton.onClick.AddListener(MainMenuReturn);
        exitMenuButtonImage.GetComponent<Button>().onClick.AddListener(MainMenuReturn);
        //
        volume= gameSettings.Volume;
        volumeSlider.value = gameSettings.Volume;
        volumeSlider.onValueChanged.AddListener(VolumeSet);
        if (gameSettings.isGame)
        {
            exitMenuButtonImage.sprite = menuSprite[0];
            activeSceneName = gameMenuSceneName;
        }
        else
        {
            //Menu Songs
            GameSettings.Instance.MenuSongs(true);
            //MenuSongs
            exitMenuButtonImage.sprite = menuSprite[1];
            activeSceneName = mainMenuSceneName;
        }
    }
    void VolumeSet(float value)
    {
        if(value>volume)
        {
            Debug.Log("Volume Poz");
            volumeBarAnimator.SetTrigger("VolumePT");
        }
        else if(value < volume)
        {
            Debug.Log("Volume Neg");
            volumeBarAnimator.SetTrigger("VolumeNT");
        }
        else
        {
            volume -= 1;
        }
        Debug.Log("Workingh");


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
