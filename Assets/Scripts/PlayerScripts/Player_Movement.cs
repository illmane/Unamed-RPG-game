using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveXValue;
    private float moveYValue;
    private Animator Anim;
    private bool isStunned;

    public static event Action<float> OnAttack;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack?.Invoke(moveXValue);
        }
    }

    void FixedUpdate()
    {
        if (isStunned == false)
        {
            MovementFunction();
        }
    }

    private void MovementFunction()
    {
        float horizontal = Input.GetAxis("Horizontal");
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
}
