using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CardStack : MonoBehaviour
{
    public float CARD_SPACING;
    private List<CardDisplay> cards = new List<CardDisplay>();

    // Start is called before the first frame update
    void Start()
    {
        AddChildrenToList();
        DisplayStack();
    }

    private void AddChildrenToList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            AddCard(transform.GetChild(i).gameObject.GetComponent<CardDisplay>());
        }
    }

    public void AddCard(CardDisplay card)
    {
        cards.Add(card);
    }

    public void RemoveCard(CardDisplay card)
    {
        cards.Remove(card);
    }

    public void DisplayStack()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.transform.localPosition = new Vector3(
                0,
                1 / CARD_SPACING * i * -1,
                0                
                );
            cards[i].gameObject.GetComponent<SortingGroup>().sortingOrder = i;
        }
    }
}
