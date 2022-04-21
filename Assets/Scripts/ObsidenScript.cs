using UnityEngine;
using UnityEngine.SceneManagement;
public class ObsidenScript : MonoBehaviour
{
    CinemachineShakeController cameraShake;
    public GameObject gamevinner;
    public string Name = "";
    public int obsidienId = 0;
    public float fireShowTime = 3f;
    public Animator animator;
    private GameObject firendly;
    private ObsidienController obsidienController;
    DialogController dialogController;
    public float cameraShakeWeak = 0.14f;
    public float cameraShakeStrong = 0.7f;
    public float cameraShakeTime = 2.1f;
    private void Start()
    {
        cameraShake = CinemachineShakeController.Instance;
        dialogController = GetComponent<DialogController>();
        obsidienController = GameObject.Find("AllObsidien").GetComponent<ObsidienController>();
        obsidienController.allObsidens[obsidienId] = false;
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
                cameraShake.CameraShakeStart(cameraShakeTime, cameraShakeWeak);
            }
            else if (obsidienController.allObsidens[obsidienId - 1] && obsidienId == obsidienController.allObsidensSize - 1 && !obsidienController.allObsidens[obsidienId])
            {
                obsidienController.allObsidens[obsidienId] = true;
                dialogController.SpecialDialogGet(3f, "Somethings Wrong");
                PlayAnimation();
                cameraShake.CameraShakeStart(cameraShakeTime+2, cameraShakeStrong);
                Debug.Log("Rituel Finish");
                Invoke("GameFinish",cameraShakeTime+2);
                
            }
            else if (!obsidienController.allObsidens[obsidienId])
            {
                if (obsidienController.allObsidens[obsidienId - 1])
                {
                    dialogController.SpecialDialogGet(3f, "I burned the obsidian, this tone scares me");
                    PlayAnimation();
                    cameraShake.CameraShakeStart(cameraShakeTime, cameraShakeWeak);
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
    void GameFinish()
    {
        SceneManager.LoadScene("Level");
    }

}
