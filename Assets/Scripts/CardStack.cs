using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Stats))]
public class CardStack : MonoBehaviour
{
    public float CARD_SPACING;
    private List<CardDisplay> cards = new List<CardDisplay>();
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
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
        List<Stats.Stat_Type> stats_types = card.card.GetStat_Types();
        for (int i = 0; i < stats_types.Count; i++)
        {
            stats.ChangeStat(stats_types[i], card.card.GetStatAmount(i));
        }
    }

    public void RemoveCard(CardDisplay card)
    {
        cards.Remove(card);
        List<Stats.Stat_Type> stats_types = card.card.GetStat_Types();
        for (int i = 0; i < stats_types.Count; i++)
        {
            stats.ChangeStat(stats_types[i], card.card.GetStatAmount(i) * -1);
        }
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

    public int GetStats(Stats.Stat_Type stat_Type)
    {
        return stats.GetStat(stat_Type);
    }
}
