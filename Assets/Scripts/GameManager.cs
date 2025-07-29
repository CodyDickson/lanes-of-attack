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
    [SerializeField] private GameObject cardSlotTwo;
    [SerializeField] private GameObject cardSlotThree;
    [SerializeField] private GameObject cardSlotFour;
    [SerializeField] private GameObject cardSlotFive;
    [SerializeField] private GameObject GUICanvas;
    private static List<string> playerDeck = new List<string>();
    private static List<string> discardPile = new List<string>();
    private int amountOfCardsInHand;

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
        DrawCard();
        DrawCard();
        DrawCard();
        DrawCard();
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
            discardPile.Add(playerDeck[0]);
            playerDeck.RemoveAt(0);
        }
        else
        {
            // Add discards to deck, shuffle deck
        }

        if (drawnCard == "lion" || drawnCard == "bear" || drawnCard == "llama")
        {
            GameObject instance = Instantiate(animalCard);
            SetCardPositionInHand(instance);
            Card script = instance.GetComponent<Card>();
            if (script != null)
            {
                script.Initialize(drawnCard);
            }
        }
        else
        {
            GameObject instance = Instantiate(modifierCard);
            SetCardPositionInHand(instance);
            Card script = instance.GetComponent<Card>();
            if (script != null)
            {
                script.Initialize(drawnCard);
            }
        }
        amountOfCardsInHand += 1;
    }

    private void SetCardPositionInHand(GameObject instance)
    {
        if (amountOfCardsInHand == 0)
        {
            instance.transform.SetParent(cardSlotOne.transform, false);
        }
        else if (amountOfCardsInHand == 1)
        {
            instance.transform.SetParent(cardSlotTwo.transform, false);
        }
        else if (amountOfCardsInHand == 2)
        {
            instance.transform.SetParent(cardSlotThree.transform, false);
        }
        else if (amountOfCardsInHand == 3)
        {
            instance.transform.SetParent(cardSlotFour.transform, false);
        }
        else if (amountOfCardsInHand == 4)
        {
            instance.transform.SetParent(cardSlotFive.transform, false);
        }
    }
}