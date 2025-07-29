using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string unitType;
    private int health;
    private int experience;
    private int level;
    private int homeNode;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] units;

    public void Initialize(string type)
    {
        unitType = type;
        SetSprite(unitType);
    }

    private void SetSprite(string type)
    {
        switch (type)
        {
            case "lion": spriteRenderer.sprite = units[0]; break;
            case "bear": spriteRenderer.sprite = units[1]; break;
            case "llama": spriteRenderer.sprite = units[2]; break;
            default: Debug.Log("No unit type"); break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy")
        {
            // move the player away in a random direction
            // remove enemy attack value from player's health

            // Get enemy health
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            int enemyHealth = enemyScript.GetEnemyHealth();
            int enemyAttack = enemyScript.GetEnemyAttack();
            health =- enemyAttack;
            if (health <= 0)
            {
                SelfDestruct();
            }
            else
            {
                experience += 1;
                if (experience >= 5)
                {
                    LevelUp();
                }
            }
        }

        if (collision.name == "Node")
        {
            // set home node to this node
        }
    }

    private void SelfDestruct()
    {
        spriteRenderer.sprite = null;
    }

    private void LevelUp()
    {
        level += 1;
        Debug.Log(unitType + " level: " + level);
    }
}