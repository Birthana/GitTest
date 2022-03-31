using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardDisplay))]
public class DeckBuilderStatsUI : MonoBehaviour
{
    public Transform iconPosition;
    public DeckBuilderStat statPrefab;
    public float CARD_SPACING;
    public float CARD_SCALING;
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
        for (int i = 0; i < stats.Count; i++)
        {
            float transformAmount = ((float)i) - ((float)stats.Count - 1) / 2;
            float angle = transformAmount * 3.0f;
            Vector3 position = new Vector3(
                Mathf.Sin(angle * Mathf.Deg2Rad),
                0,
                0
                ) * CARD_SPACING;
            stats[i].gameObject.transform.localPosition = position + iconPosition.localPosition;
            stats[i].gameObject.transform.localScale = new Vector3(CARD_SCALING, CARD_SCALING);
        }
    }
}
