using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    public string column="";
    private string password = "4321";
    void Update()
    {
        if (column==password)
        {
            GameWin();
        }
        Debug.Log("CurrentPassword" + column);
    }
    public void GameWin()
    {
        SceneManager.LoadScene("GameFinish");
        Debug.Log("GameWin");
    }
}
