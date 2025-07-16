using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private string unitType;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] units;

    public void Initialize(string type)
    {
        unitType = type;
        SetSprite(unitType);
    }

    private void SetSprite(string type)
    {
        switch (type)
        {
            case "lion": spriteRenderer.sprite = units[0]; break;
            case "bear": spriteRenderer.sprite = units[1]; break;
            case "llama": spriteRenderer.sprite = units[2]; break;
            default: Debug.Log("No unit type"); break;
        }
    }
}