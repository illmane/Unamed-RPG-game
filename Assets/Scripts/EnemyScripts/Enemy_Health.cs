using System.Collections;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
   public float currentHealth;
   public float Maxhealth;

   private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float STAY_RED_TIME = 0.08f;
    private Color colour1;

    void Start()
    {
        currentHealth = Maxhealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void takeDamage()
    {
        currentHealth -= StatsManager.Instance.damageAmount;
        rb.linearVelocity = Vector2.zero;
        StartCoroutine(damageFeedback());
        
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator damageFeedback()
    {
        ColorUtility.TryParseHtmlString("#FF0000", out colour1);
        spriteRenderer.color = colour1;

        yield return new WaitForSeconds(STAY_RED_TIME);

        ColorUtility.TryParseHtmlString("#FFFFFF", out colour1);
        spriteRenderer.color = colour1;
    }
}
