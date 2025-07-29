using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite nodeSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerUnit")
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "PlayerUnit")
        {
            spriteRenderer.enabled = true;
        }
    }
}
