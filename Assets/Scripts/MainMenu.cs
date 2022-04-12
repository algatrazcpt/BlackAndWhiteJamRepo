using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName = "OpenLevel";
    void Start()
    {
        GameSettings.Instance.isGame = false;
        GameSettings.Instance.MenuSongs(true);
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Play()
    {
        GameSettings.Instance.MenuSongs(false);
        SceneManager.LoadScene(playSceneName);
    }
}
