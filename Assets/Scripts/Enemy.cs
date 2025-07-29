using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int currentHealth;
    private int currentAttack;

    public int GetEnemyHealth()
    {
        int health = 0;
        health = currentHealth;
        return health;
    }
    public int GetEnemyAttack()
    {
        int attack = 0;
        attack = currentAttack;
        return attack;
    }
}
