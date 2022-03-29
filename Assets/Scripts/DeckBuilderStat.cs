using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckBuilderStat : MonoBehaviour
{
    public Sprite icon;
    public TextMeshPro amountText;
    public int amount 
    {
        get
        {
            return amount;
        }
        set
        {
            amountText.text = $"+{value}";
        }
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void SetIcon(Sprite newIcon)
    {
        icon = newIcon;
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}
