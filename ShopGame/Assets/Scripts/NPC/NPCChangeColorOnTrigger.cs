using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChangeColorOnTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Color newColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            ChangeSpriteColor();
        }
    }

    private void ChangeSpriteColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = newColor;
        }
    }
}
