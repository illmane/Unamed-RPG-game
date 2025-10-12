using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementFunction();
    }

    private void MovementFunction()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontal * StatsManager.Instance.MovementSpeed, vertical * StatsManager.Instance.MovementSpeed);

    }
}
