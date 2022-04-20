using UnityEngine;
using UnityEngine.SceneManagement;
public class ObsidenScript : MonoBehaviour
{
    public GameObject gamevinner;
    public string Name = "";
    public int obsidienId = 0;
    public float fireShowTime = 3f;
    public Animator animator;
    private GameObject firendly;
    private ObsidienController obsidienController;
    DialogController dialogController;
    private void Start()
    {
        dialogController = GetComponent<DialogController>();
        obsidienController = GameObject.Find("AllObsidien").GetComponent<ObsidienController>();
        obsidienController.allObsidens[obsidienId] = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FriendlyFire"))
        {
            if (obsidienId == 0 && !obsidienController.allObsidens[obsidienId])
            {
                obsidienController.allObsidens[obsidienId] = true;
                dialogController.SpecialDialogGet(3f, "I burned the obsidian, this tone scares me");
                PlayAnimation();
            }
            else if (obsidienController.allObsidens[obsidienId - 1] && obsidienId == obsidienController.allObsidensSize - 1 && !obsidienController.allObsidens[obsidienId])
            {
                obsidienController.allObsidens[obsidienId] = true;
                dialogController.SpecialDialogGet(3f, "I burned the obsidian, this tone scares me");
                PlayAnimation();
                Debug.Log("Rituel Finish");
                SceneManager.LoadScene("Level");
            }
            else if (!obsidienController.allObsidens[obsidienId])
            {
                if (obsidienController.allObsidens[obsidienId - 1])
                {
                    dialogController.SpecialDialogGet(3f, "I burned the obsidian, this tone scares me");
                    PlayAnimation();
                }
            }
        }
    }
    void PlayAnimation()
    {
        animator.SetTrigger("FireT");
        Invoke("DeleteFire", fireShowTime);
    }
    void DeleteFire()
    {
        Destroy(firendly);
    }

}
