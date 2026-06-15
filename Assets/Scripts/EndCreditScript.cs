using UnityEngine;

public class EndCreditScript : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void StartScrolling()
    {
        anim.SetBool("StartScroll", true);
    }
}
