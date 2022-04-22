using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CutSceneDialogController : MonoBehaviour
{
    string sceneName = "GamePlayLevel";
    public string[] allDialogs = new string[7];
    public TMP_Text dialogText;
    public Animator dialogAnimator;
    public TMP_Text enemyDialog;
    public Animator dialogAnimator2;
    private int dialog›d = 0;
    public float dialogShowtime = 7f;
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        allDialogs[0] = "I'm not holding you prisoner here, I'll set you free";
        allDialogs[1] = "You can't understand me but after the ritual you will be free";
        allDialogs[2] = "I must start the ritual right away without waiting any longer.";
        allDialogs[3] = "You helpless creature I don't want your service anymore you can die";
        allDialogs[4] = "How did that happen. The magic barrier is insurmountable. (It looks so scary)";
        allDialogs[5] = "And you interfere with my business. You can't even stand in front of me.";
        allDialogs[6] = "You're not my equal I'm sending you where you belong";
    }
    public void DialogGet()
    {
        Debug.Log(dialog›d);
        if (dialog›d < 3)
        {
            dialogText.text = allDialogs[dialog›d];
            StartCoroutine("DialogShow");
            NextDialog();
            
        }
        else if(dialog›d==3)
        {
            enemyDialog.text = allDialogs[dialog›d];
            StartCoroutine("DialogShow2");
            NextDialog();
        }
        else if(dialog›d==4)
        {
            dialogText.text = allDialogs[dialog›d];
            StartCoroutine("DialogShow");
            NextDialog();
            //
            enemyDialog.text = allDialogs[dialog›d];
            StartCoroutine("DialogShow2");
            NextDialog();

        }
        else if(dialog›d==6)
        {
            enemyDialog.text = allDialogs[dialog›d];
            StartCoroutine("DialogShow2");
            NextDialog();
        }
        else
        {
            dialog›d = 0;
        }
    }
    void NextDialog()
    {
        if (dialog›d < allDialogs.Length - 1)
        {
            dialog›d += 1;
        }
    }
    public void CutSceneFinish()
    {
        SceneManager.LoadScene(sceneName);
    }






    IEnumerator DialogShow()
    {
        //DialogShow
        dialogAnimator.SetBool("DialogStartB", true);
        yield return new WaitForSeconds(dialogShowtime);
        //DialogClose
        dialogAnimator.SetBool("DialogStartB", false);
    }
    IEnumerator DialogShow2()
    {
        //DialogShow
        dialogAnimator2.SetBool("DialogStartB", true);
        yield return new WaitForSeconds(dialogShowtime);
        //DialogClose
        dialogAnimator2.SetBool("DialogStartB", false);
    }
    public void CustomDialogGet(int value)
    {
        dialogText.text = allDialogs[value];
        StartCoroutine("DialogShow");
    }
    public void SpecialDialogGet(float time, string dialog)
    {
        StartCoroutine(SpecialDialogShow(time, dialog));
    }
    IEnumerator SpecialDialogShow(float time, string dialog)
    {
        dialogAnimator.SetBool("DialogStartB", true);
        dialogText.text = dialog;
        yield return new WaitForSeconds(time);
        dialogAnimator.SetBool("DialogStartB", false);
    }
}
