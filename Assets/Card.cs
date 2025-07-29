using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Image imageChild;
    [SerializeField] private Sprite[] units;
    [SerializeField] private TMP_Text text_attack, text_health;
    private int attackValue;
    private int healthValue;

    public void Initialize(string type)
    {
        switch (type)
        {
            case "lion": SetImageOfChild(0); attackValue = 3; healthValue = 10; break;
            case "bear": SetImageOfChild(1); attackValue = 8; healthValue = 5; break;
            case "llama": SetImageOfChild(2); attackValue = 1; healthValue = 15; break;
            default: Debug.Log("ERROR: Card not set"); break;
        }
        text_attack.text = attackValue.ToString();
        text_health.text = healthValue.ToString();
    }

    private void SetImageOfChild(int type)
    {
        imageChild = transform.GetChild(0).GetComponent<Image>();
        imageChild.sprite = units[type];
    }
}
