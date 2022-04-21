using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public int currentDeat=1;

    private void Update()
    {
    }
        /*
        if(Input.GetKeyDown("l"))
        {
            SaveData
            JsonTEst v=GameDialogController.LoadGame();
            if (v != null)
            {
                Debug.Log(v.inGameDialog[v.currentDeathId]);
            }
        }
        if (Input.GetKeyDown("p"))
        {
            JsonTEst v = GameDialogController.LoadGame();
            currentDeat = v.currentDeathId+1;
            GameDialogController.SaveGame(currentDeat);
        }
    }
    public void SaveControl()
    {
        SaveData v= GameSaveSystem.LoadGame();
        currentDeat = v.currentDeathId + 1;
        GameDialogController.SaveGame(currentDeat);
    }*/
}
