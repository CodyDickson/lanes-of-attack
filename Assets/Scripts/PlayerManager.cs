using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] string _color;
    [SerializeField] string _faction;
    [SerializeField] int _gold;

    void Awake()
    {
        // From the main menu, set the player's colors and factions

        // Enable AI component if computer player
    }

    void Update()
    {
    }
}