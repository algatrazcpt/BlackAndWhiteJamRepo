using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogController : MonoBehaviour
{
    public string[] allDialogs;
    public TMP_Text dialogText;
    public Animator dialogAnimator;
    private int dialog›d = 0;
    public float dialogShowtime = 7f;
    int multiDialogStopCount = 0;
    int multiDialogCount = 0;
    public bool isMissionState = false;
    public FriendlyMagicControl magicControl;
    public void DialogGet()
    {
        dialogText.text = allDialogs[dialog›d];
        StartCoroutine("DialogShow");
        NextDialog();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //DialogGet();
        }
    }
    void NextDialog()
    {
        if (dialog›d < allDialogs.Length - 1)
        {
            dialog›d += 1;
        }
    }
    public void MultiDialogGet(int startId, int stopId)
    {
        dialog›d = startId;
        multiDialogStopCount = stopId;
        multiDialogCount = dialog›d;
        StartCoroutine(MultiDialog());
    }
    IEnumerator MultiDialog()
    {
        if (multiDialogCount >= multiDialogStopCount)
        {
            magicControl.ColliderActiviteController(true);
            StartCoroutine(magicControl.playerMoveControl(true));
            StopCoroutine(MultiDialog());
        }
        else
        {
            multiDialogCount++;
            DialogGet();
            yield return new WaitForSeconds(dialogShowtime +0.5f);
            StartCoroutine(MultiDialog());
        }
    }
    IEnumerator DialogShow()
    {
        //DialogShow
        dialogAnimator.SetBool("DialogStartB", true);
        yield return new WaitForSeconds(dialogShowtime);
        //DialogClose
        dialogAnimator.SetBool("DialogStartB", false);


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
