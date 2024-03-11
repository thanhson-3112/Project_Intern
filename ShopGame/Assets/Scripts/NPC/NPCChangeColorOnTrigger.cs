using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChangeColorOnTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color newColor;
    private Color originalColor;

    private void Start()
    {
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            ChangeSpriteColor(newColor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            ChangeSpriteColor(originalColor);
        }
    }

    private void ChangeSpriteColor(Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}
