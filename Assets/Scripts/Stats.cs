using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats : MonoBehaviour
{
    public enum Stat_Type { HP, MP, POW, DEF, INT, SPD };
    [SerializeField]
    private List<Stat_Type> Stat_Types = new List<Stat_Type>() { 
        Stat_Type.HP, Stat_Type.MP, Stat_Type.POW, 
        Stat_Type.DEF, Stat_Type.INT, Stat_Type.SPD
    };
    [SerializeField]
    private List<int> Stat_Amounts = new List<int>() {
        0, 0, 0, 0, 0, 0
    };

    public int GetStat(Stat_Type type)
    {
        return Stat_Amounts[(int)type];
    }
}
