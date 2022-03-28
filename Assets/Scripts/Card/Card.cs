using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public Trigger trigger;
    public int MPCost;
    public List<Effect> effects;
    [TextArea(3, 5)]
    public string cardEffect;

    [SerializeField]
    private List<Stats.Stat_Type> stat_types = new List<Stats.Stat_Type>();
    [SerializeField]
    private List<int> stat_amount = new List<int>();

    public List<Stats.Stat_Type> GetStat_Types()
    {
        return stat_types;
    }

    public int GetStatAmount(int i)
    {
        return stat_amount[i];
    }

    public Trigger GetTrigger()
    {
        return trigger;
    }
}
