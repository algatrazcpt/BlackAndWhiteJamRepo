using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsMenuController : MonoBehaviour
{
    public static SettingsMenuController Instance;
    public GameSettings gameSettings;
    public GameObject mainMenuUi;
    public Button exitMenuButton;
    public Button mainMenuReturnButton;
    public Slider volumeSlider;
    private float volume = 0.5f;
    public bool isMainMenuScene=true;
    public string mainMenuSceneName = "MainMenu";
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        exitMenuButton.onClick.AddListener(SettingsMenuClose);
        mainMenuReturnButton.onClick.AddListener(MainMenuReturn);
        volumeSlider.onValueChanged.AddListener(VolumeSet);
        gameObject.SetActive(false);
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.Volume = volume;
    }

    void VolumeSet(float value)
    {
        volume = value;
        gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gameSettings.Volume = value;
    }
    public float VolumeGet()
    {
        return volume;
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene(mainMenuSceneName);
        SettingsMenuClose();
        
    }
    public void SettingsMenuShow()
    {
        if(isMainMenuScene)
        {
            gameObject.SetActive(true);
            mainMenuReturnButton.gameObject.SetActive(false);
            
        }
        else
        {
            gameObject.SetActive(true);
            mainMenuReturnButton.gameObject.SetActive(true);
        }
    }
    public void SettingsMenuClose()
    {
        if(isMainMenuScene)
        {
            mainMenuUi.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
