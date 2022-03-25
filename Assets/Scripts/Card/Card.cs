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

    public Trigger GetTrigger()
    {
        return trigger;
    }
}
