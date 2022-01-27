using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats : MonoBehaviour
{
    public enum Stat_Type { HP, MP, POW, DEF, INT, SPD };
    public List<Stat_Type> statType = new List<Stat_Type>() { 
        Stat_Type.HP, Stat_Type.MP, Stat_Type.POW,
        Stat_Type.DEF, Stat_Type.INT, Stat_Type.SPD };
    public List<int> statValues = new List<int>() { 0, 0, 0, 0, 0, 0};
}
