using System.Collections;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing = false;
    private float DASHING_TIME = 0.5f;
    private Rigidbody2D rb;
    private ControllerActionMap Controls;


    void Awake()
    {       
        Controls = new ControllerActionMap();

        Controls.Combat.Dash.performed += ctx => StartCoroutine(Dash()); 

    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(2f, 0f);
    }

    public IEnumerator Dash()
    {
        if (canDash == true)
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            // rb.gravityScale = 0f;

            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(horizontal*StatsManager.Instance.DashingPower, 0f);

            yield return new WaitForSeconds(DASHING_TIME);
            rb.gravityScale = originalGravity;
            isDashing = false;

            yield return new WaitForSeconds(StatsManager.Instance.DashingCooldown);
            canDash = true;
        }

    }

    void OnEnable()
    {
        Controls.Combat.Enable();
    }

    void OnDisable()
    {
        Controls.Combat.Disable();   
    }
}
