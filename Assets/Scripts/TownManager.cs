using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    [SerializeField] int _gold;
    [SerializeField] int _growth;
    [SerializeField] int _growthMax;
    [SerializeField] int _growthMin;

    // Each position on the table correlates to a player
    [SerializeField] int[] _influenceTable;

    private void Update()
    {
        
    }
}