using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject node;
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
    private static List<Vector2> lane_starting_positions = new List<Vector2>();
    private static List<Vector2> all_lane_positions = new List<Vector2>();
    private int amountOfCardsInHand;
    private int handMax;
    private int currentTurn;
    private int numberOfLanes;
    [SerializeField] int _amountOfPlayers;

    void Start()
    {
        // Initial settings
        handMax = 5;
        currentTurn = 0;
        numberOfLanes = 3;

        PopulateOriginalDeck();
        FillHand(handMax);
        GenerateLane(numberOfLanes);
    }

    private void GenerateLane(int amount)
    {
        Vector2 vector2 = Vector2.zero;
        
        for (int i = 0; i < amount; i++)
        {
            int randomXorY = Random.Range(0,2);
            int randomInt = Random.Range(1, 11);
            if (randomXorY == 0)
            {
                vector2.x = randomInt;
            }
            else
            {
                vector2.y = randomInt;
            }
            bool starting_position_determined = false;
            while (!starting_position_determined)
            {
                bool exists = lane_starting_positions.Contains(vector2);
                if (!exists)
                {
                    starting_position_determined = true; lane_starting_positions.Add(vector2);
                    all_lane_positions.Add(vector2);
                }
            }

            int random_lane_length = Random.Range(5,11);

            for (int j = 0; j < random_lane_length; j++)
            {
                if (randomXorY == 0)
                {
                    vector2.y = j;
                }
                else
                {
                    vector2.x = j;
                }
                Instantiate(node, vector2, Quaternion.identity);
                all_lane_positions.Add(vector2);
            }
        }
    }

    private void FillHand(int max)
    {
        for (int i = 0; i < max; i++)
        {
            DrawCard();
        }
    }

    private void PopulateOriginalDeck()
    {
        for (int x =  0; x < 3; x++)
        {
            // high movement
            playerDeck.Add("scout");
        }
        for (int x = 0; x < 3; x++)
        {
            // high attack
            playerDeck.Add("warrior");
        }
        for (int x = 0; x < 3; x++)
        {
            // ranged attack
            playerDeck.Add("archer");
        }
        for (int x = 0; x < 5; x++)
        {
            playerDeck.Add("increase_attack");
        }
        for (int x = 0; x < 5; x++)
        {
            playerDeck.Add("increase_health");
        }
        for (int x = 0; x < 5; x++)
        {
            playerDeck.Add("grant_experience");
        }
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
        // GameObject instance = Instantiate(playerUnit, lanePositionOne, Quaternion.identity);
        // Player script = instance.GetComponent<Player>();
        // if (script != null)
        //{
            //script.Initialize("lion");
        //}
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