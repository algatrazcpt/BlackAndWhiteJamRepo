using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeControl : MonoBehaviour
{
    public void Start()
    {
        Invoke("ChangeScene", 134f);
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Level");
    }
}
