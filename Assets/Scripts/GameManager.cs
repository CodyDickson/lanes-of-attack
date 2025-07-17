using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject node;
    private Vector3 lanePositionOne = new Vector3(0, 0, 0);
    private Vector3 lanePositionTwo = new Vector3(2, 0, 0);
    private Vector3 lanePositionThree = new Vector3(4, 0, 0);
    [SerializeField] private GameObject playerUnit;
    [SerializeField] private GameObject animalCard;
    [SerializeField] private GameObject modifierCard;
    [SerializeField] private GameObject cardSlotOne;
    [SerializeField] private GameObject GUICanvas;
    private static List<string> playerDeck = new List<string>();

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
        PopulateOriginalDeck();
        Debug.Log("Deck Amount: " + playerDeck.Count);
        DrawCard();
    }

    private void PopulateOriginalDeck()
    {
        playerDeck.Add("lion");
        playerDeck.Add("lion");
        playerDeck.Add("lion");
        playerDeck.Add("bear");
        playerDeck.Add("bear");
        playerDeck.Add("bear");
        playerDeck.Add("llama");
        playerDeck.Add("llama");
        playerDeck.Add("llama");
        playerDeck.Add("attackModifier");
        playerDeck.Add("attackModifier");
        playerDeck.Add("attackModifier");
        playerDeck.Add("healthModifier");
        playerDeck.Add("healthModifier");
        playerDeck.Add("healthModifier");
        ShuffleDeck(playerDeck);
    }

    private void ShuffleDeck(List<string> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            string temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
        Debug.Log("List: " + list[0]);
        // return list;
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
        string drawnCard = "";
        if (playerDeck.Count > 0)
        {
            drawnCard = playerDeck[0];
            Debug.Log(drawnCard);
        }
        else
        {
            // Add discards to deck, shuffle deck
        }

        if (drawnCard == "lion" || drawnCard == "bear" || drawnCard == "llama")
        {
            GameObject instance = Instantiate(animalCard);
            instance.transform.SetParent(cardSlotOne.transform, false);
            Card script = instance.GetComponent<Card>();
            if (script != null)
            {
                script.Initialize(drawnCard);
            }
        }
        else
        {
            GameObject instance = Instantiate(modifierCard);
            instance.transform.SetParent(cardSlotOne.transform, false);
            Card script = instance.GetComponent<Card>();
            if (script != null)
            {
                script.Initialize(drawnCard);
            }
        }
    }
}