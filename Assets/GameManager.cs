using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject node;
    private Vector3 lanePositionOne = new Vector3(0, 0, 0);
    private Vector3 lanePositionTwo = new Vector3(2, 0, 0);
    private Vector3 lanePositionThree = new Vector3(4, 0, 0);
    [SerializeField] private GameObject playerUnit;

    void Start()
    {
        Instantiate(playerUnit, lanePositionOne, Quaternion.identity);

        for (int x = 0; x < 5; x++)
        {
            Instantiate(node, lanePositionOne, Quaternion.identity);
            Instantiate(node, lanePositionTwo, Quaternion.identity);
            Instantiate(node, lanePositionThree, Quaternion.identity);
            lanePositionOne.y += 2;
            lanePositionTwo.y += 2;
            lanePositionThree.y += 2;
        }
        
    }

    void Update()
    {
        
    }
}