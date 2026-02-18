using System;
using UnityEngine;

public class TriggerDashText : MonoBehaviour
{
    public static event Action OnPassingArchway;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPassingArchway?.Invoke();
        }
    }
}
