using UnityEngine;

public class ObsidenScript : MonoBehaviour
{
    public GameObject gamevinner;
    public string Name = "";
    public Animator animator;
    private GameObject firendly;
    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Start2");
        if (collision.gameObject.CompareTag("FriendlyFire"))
        {
            Debug.Log("Start");
            animator.SetTrigger("FireT");
            firendly = collision.gameObject;
            Invoke("DeleteFire", 3f);
            gamevinner.gameObject.GetComponent<GameWinner>().column += Name;
        }
    }
    void DeleteFire()
    {
        Destroy(firendly);
    }

}
