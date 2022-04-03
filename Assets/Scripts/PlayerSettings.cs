using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSettings : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&GameSettings.Instance.isSettingsOneOpen)
        {
            GameSettings.Instance.isGame = true;
            GameSettings.Instance.TimeControl(true);
            SceneManager.LoadScene("Setting", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameSettings.Instance.isSettingsOneOpen = true;
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Setting"));
            GameSettings.Instance.TimeControl(false);
        }

    }
}
