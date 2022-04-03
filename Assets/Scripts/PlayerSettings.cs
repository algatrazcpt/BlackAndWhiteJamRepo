using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    private SettingsMenuController settingsMenuUicontroller;
    bool isSettingsMenuShow=false;
    private void Start()
    {
        settingsMenuUicontroller=GameObject.Find("SettingsMenuUi").GetComponent<SettingsMenuController>();
        settingsMenuUicontroller.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsMenuShow)
            {
                settingsMenuUicontroller.SettingsMenuClose();
                isSettingsMenuShow = false;
            }
            else
            {

                settingsMenuUicontroller.SettingsMenuShow();
                isSettingsMenuShow = true;
            }
        }
    }
}
