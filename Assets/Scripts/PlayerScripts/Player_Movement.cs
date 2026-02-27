using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveXValue;
    private float moveYValue;
    private Animator Anim;
    private bool isStunned;
    private ControllerActionMap Controls;
    private bool canDash = true;
    private bool isDashing = false;
    private float DASHING_TIME = 0.20f;
    private float horizontal;
    

    public static event Action<float, float> OnAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Controls = new ControllerActionMap();

        Controls.Combat.Strike.performed += ctx => OnAttack?.Invoke(moveXValue, horizontal);
        Controls.Combat.Dash.performed += ctx => StartCoroutine(Dash()); 
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack?.Invoke(moveXValue, horizontal);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (isStunned == false && isDashing == false)
        {
            MovementFunction();
        }
        if (isDashing == true)
        {
            return;
        }
    }

    private void MovementFunction()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f)
        {
            Anim.SetBool("isMoving", true);
        }
        else if (horizontal == 0f && vertical == 0f)
        {
            Anim.SetBool("isMoving", false);
        }
        if (horizontal < -StatsManager.Instance.ControllerDeadZone)
        {
            moveXValue = -1;
            moveYValue = 0f;
        }
        else if (horizontal > StatsManager.Instance.ControllerDeadZone)
        {
            moveXValue = 1;
            moveYValue = 0f;
        }

        if (vertical < -StatsManager.Instance.ControllerDeadZone)
        {
            moveXValue = 0;
            moveYValue = -1f;
        }
        else if (vertical > StatsManager.Instance.ControllerDeadZone)
        {
            moveXValue = 0;
            moveYValue = 1f;
        }

        Anim.SetFloat("MoveX", moveXValue);
        Anim.SetFloat("MoveY", moveYValue);

        rb.linearVelocity = new Vector2(horizontal * StatsManager.Instance.MovementSpeed, vertical * StatsManager.Instance.MovementSpeed);
    }

    private IEnumerator StunnedTimer()
    {
        yield return new WaitForSeconds(StatsManager.Instance.StunnedTimer);
        rb.linearVelocity = Vector2.zero;
        isStunned = false;
    }

    public void GetStunned(Transform enemy)
    {
        isStunned = true;
        Vector2 StunnedDirection = transform.position - enemy.position;
        rb.linearVelocity = StunnedDirection * StatsManager.Instance.StunnedPower;
        StartCoroutine(StunnedTimer());
    }

    public IEnumerator Dash()
    {
        if (canDash == true)
        {
            Anim.SetBool("CanDash", canDash);
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            // rb.gravityScale = 0f;

            DashDirection();

            yield return new WaitForSeconds(DASHING_TIME);
            rb.gravityScale = originalGravity;
            isDashing = false;

            Anim.SetBool("CanDash", canDash);
            yield return new WaitForSeconds(StatsManager.Instance.DashingCooldown);
            canDash = true;
        }

    }

    private void DashDirection()
    {
        if (moveXValue == 1f && moveYValue == 0)
        {
            rb.linearVelocity = new Vector2(StatsManager.Instance.DashingPower, 0f);
        }
        else if (moveXValue == -1f && moveYValue == 0)
        {
            rb.linearVelocity = new Vector2(-StatsManager.Instance.DashingPower, 0f);
            
        }
        if (moveXValue == 0f && moveYValue == 1f)
        {
            rb.linearVelocity = new Vector2(0f, StatsManager.Instance.DashingPower);
        }
        else if (moveXValue == 0f && moveYValue == -1f)
        {
            rb.linearVelocity = new Vector2(0f, -StatsManager.Instance.DashingPower);
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
