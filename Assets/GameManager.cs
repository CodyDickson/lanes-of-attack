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
    [SerializeField] private GameObject animalCard;
    [SerializeField] private GameObject cardSlotOne;
    [SerializeField] private GameObject GUICanvas;

    void Start()
    {
        SpawnUnit();

        for (int x = 0; x < 5; x++)
        {
            Instantiate(node, lanePositionOne, Quaternion.identity);
            Instantiate(node, lanePositionTwo, Quaternion.identity);
            Instantiate(node, lanePositionThree, Quaternion.identity);
            lanePositionOne.y += 2;
            lanePositionTwo.y += 2;
            lanePositionThree.y += 2;
        }

        DrawCard();
    }

    private void SpawnUnit()
    {
        GameObject instance = Instantiate(playerUnit, lanePositionOne, Quaternion.identity);
        UnitManager script = instance.GetComponent<UnitManager>();
        if (script != null)
        {
            script.Initialize("lion");
        }
    }

    private void DrawCard()
    {
        GameObject instance = Instantiate(animalCard, lanePositionOne, Quaternion.identity);
        instance.transform.SetParent(GUICanvas.transform, false);
        // instance.transform = cardSlotOne.transform;
        RectTransform rectTransform = instance.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(90, 90);
        UnitManager script = instance.GetComponent<UnitManager>();
        if (script != null)
        {
            script.Initialize("lion");
        }
    }
}