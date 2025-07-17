using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Image imageChild;
    [SerializeField] private Sprite[] units;
    [SerializeField] private TMP_Text text_attack, text_health, text_modifier;
    private int attackValue = 0;
    private int healthValue = 0;

    public void Initialize(string type)
    {
        switch (type)
        {
            case "lion": SetImageOfChild(0); SetCardValues(5, 10); break;
            case "bear": SetImageOfChild(1); SetCardValues(10, 5); break;
            case "llama": SetImageOfChild(2); SetCardValues(3, 15); break;
            case "attackModifier": SetModifierText(0); break;
            case "healthModifier": SetModifierText(1); break;
            default: Debug.Log("ERROR: Card not set"); break;
        }

    }

    private void SetImageOfChild(int type)
    {
        imageChild = transform.GetChild(0).GetComponent<Image>();
        imageChild.sprite = units[type];
    }

    private void SetCardValues(int attack, int health)
    {
        text_attack.text = attack.ToString();
        text_health.text = health.ToString();
        attackValue = attack;
        healthValue = health;
    }

    private void SetModifierText(int type)
    {
        switch (type)
        {
            case 0: text_modifier.text = "+2 AP"; break;
            case 1: text_modifier.text = "+2 HP"; break;
            default: Debug.Log("No modifier card"); break;
        }
    }
}
