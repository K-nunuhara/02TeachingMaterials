using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlantStates;

public abstract class Plant : LivingEntity
{
    public string uid = System.Guid.NewGuid().ToString();
    public PlantGene gene;
    public IPlantState state;
    public PlantStats stats;
}
