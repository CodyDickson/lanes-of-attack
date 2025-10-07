using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderManager : MonoBehaviour
{
    [SerializeField] int _belongsToPlayer;
    [SerializeField] int _armySize;

    // Health, Strength, Defense, Lives, Critical Hit Chance
    [SerializeField] int[] _stats;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Underneath the commander in the hierarchy, Units can be spawned. If they exit the Commander's army, they spawn as a new game object which has the UnitManager script on it.
}
