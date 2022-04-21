using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAllControls : MonoBehaviour
{
    public string sceneName = "Level";
    Animator animator;
    private Vector3 moveDelta;
    private bool rituelCast;
    public GameObject fire;
    public DialogController dialogController;
    void Start()
    {
        animator = GetComponent<Animator>();
        dialogController = GetComponent<DialogController>();
        SaveData saveData = GameSaveSystem.LoadGame();
        dialogController.SpecialDialogGet(3f,saveData.LoadDialog());
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) & rituelCast == true)
        {
            rituelCast = false;
            GetFire();
        }
        PlayerMove();
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0 | y != 0)
        {
            animator.SetFloat("speed", 1.5f);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
        moveDelta = new Vector3(x, y, 0);
        //swap right or left
        if (moveDelta.x > 0)
        {
            //transform.localScale = Vector3.one;
            transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
        }
        else if (moveDelta.x < 0)
        {
            //transform.localScale=new  Vector3(-1, 1,1);
            transform.localScale = new Vector3(-0.16f, 0.16f, 0.16f);
        }
        transform.position += moveDelta * Time.deltaTime;
    }
    void GetFire()
    {
        Instantiate(fire, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RituelPoint"))
        {
                rituelCast = true;
                dialogController.SpecialDialogGet(2f, dialogController.allDialogs[6]);
        }
    }
    public void  PlayerDeath()
    {
       animator.SetTrigger("PlayerDeathT");
        Invoke("DeathScene", 1.5f);
    }
    public void DeathScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
