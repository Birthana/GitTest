using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatCheck", menuName = "Condition/StatCheck")]
public class StatCheck : Condition
{
    public Stats.Stat_Type stat_type;
    public int value;
    public enum Comparsion { Less_Than, Greater_Than, Equal_To,
            Less_Than_or_Equal_To, Greater_Than_or_Equal_To};
    public Comparsion comparsion;

    public override bool CheckCondition(Character character)
    {
        bool result = true;
        int characterStat = character.GetStat(stat_type);
        if (comparsion == Comparsion.Less_Than)
        {
            result = characterStat < value;
        }else if (comparsion == Comparsion.Greater_Than)
        {
            result = characterStat > value;
        }else if (comparsion == Comparsion.Equal_To)
        {
            result = characterStat == value;
        }else if (comparsion == Comparsion.Less_Than_or_Equal_To)
        {
            result = characterStat <= value;
        }else if (comparsion == Comparsion.Greater_Than_or_Equal_To)
        {
            result = characterStat >= value;
        }
        return result;
    }
}
