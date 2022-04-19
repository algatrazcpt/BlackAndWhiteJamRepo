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
    public float dialogShowtime=7f;
    public void DialogGet()
    {
        dialogText.text = allDialogs[dialog›d];
        StartCoroutine("DialogShow");
        NextDialog();
    }
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            DialogGet();
        }
    }
    void NextDialog()
    {
        if (dialog›d < allDialogs.Length-1)
        {
            dialog›d += 1;
        }
    }
    public bool MultiDialogGet(int startId,int stopId)
    {
        for (int a = startId; a < stopId; a++)
        {

            DialogGet();
            Debug.Log(a);
            new WaitForSeconds(5f);
        }
        return true;
    }
    IEnumerator DialogShow()
    {
        //DialogShow
        dialogAnimator.SetBool("DialogStartB", true);
        yield return new WaitForSeconds(dialogShowtime);
        Debug.Log("Not Wait");
        //DialogClose
        dialogAnimator.SetBool("DialogStartB", false);
       

    }
    public void CustomDialogGet(int value)
    {
        dialogText.text = allDialogs[value];
        StartCoroutine("DialogShow");
    }
}
