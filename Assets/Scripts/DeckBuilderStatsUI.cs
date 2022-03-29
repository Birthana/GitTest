using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardDisplay))]
public class DeckBuilderStatsUI : MonoBehaviour
{
    public Transform iconPosition;
    public DeckBuilderStat statPrefab;
    public List<Sprite> icons = new List<Sprite>();
    private List<DeckBuilderStat> stats = new List<DeckBuilderStat>();

    private void Awake()
    {
        GetComponent<CardDisplay>().OnCardChange += DisplayIcons;
    }

    //Test Function
    private void Start()
    {
        DisplayIcons(GetComponent<CardDisplay>().card);
    }

    public void DisplayIcons(Card card)
    {
        List<Stats.Stat_Type> addedStats = card.GetStat_Types();
        for (int i = 0; i < addedStats.Count; i++)
        {
            DeckBuilderStat newStat = Instantiate(statPrefab, transform);
            newStat.SetIcon(icons[(int)addedStats[i]]);
            newStat.amount = card.GetStatAmount(i);
            stats.Add(newStat);
        }
        SetPositions();
    }

    public void SetPositions()
    {

    }
}
