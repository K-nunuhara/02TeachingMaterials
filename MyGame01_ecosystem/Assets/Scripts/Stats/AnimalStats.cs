using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create AnimalStats")]
public class AnimalStats : LivingEntityStats
{
    public int AnimalPoint; // Score or Money in the game
    public int MAX_BREED;
    public float EAT_DURATION;
    public float DRINK_DURATION;
    public Species.Type[] DIET;
}
