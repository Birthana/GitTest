using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats : MonoBehaviour
{
    public static Stat_Type HP = Stat_Type.HP;
    public static Stat_Type MP = Stat_Type.MP;
    public static Stat_Type POW = Stat_Type.POW;
    public static Stat_Type DEF = Stat_Type.DEF;
    public static Stat_Type INT = Stat_Type.INT;
    public static Stat_Type SPD = Stat_Type.SPD;
    public enum Stat_Type { HP, MP, POW, DEF, INT, SPD };
    [SerializeField]
    private List<Stat_Type> statType = new List<Stat_Type>() { 
        Stat_Type.HP, Stat_Type.MP, Stat_Type.POW,
        Stat_Type.DEF, Stat_Type.INT, Stat_Type.SPD };
    [SerializeField]
    private List<int> statValues = new List<int>() { 0, 0, 0, 0, 0, 0};

    public int GetStat(Stat_Type stat_type)
    {
        return statValues[(int)stat_type];
    }
}
