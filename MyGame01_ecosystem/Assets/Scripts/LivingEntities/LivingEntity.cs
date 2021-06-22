using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LivingEntity : MonoBehaviour
{
    public int age;
    public bool isAdult;
    public float health;
    public float calorie;
    public float water;
    public GameObject ui;
    public Slider slider;
    // public Genus genus;

    public abstract void Grow();
    public abstract void ConsumeCalorie();
    public abstract void ConsumeWater();
    public abstract void InTakeCalorie();
    public abstract void InTakeWater();
    //public abstract LivingEntity Bleed(Gene momGene, Gene dadGene);

    public void Die()
    {
        // TODO: Play dying animation and wait few seconds
        Destroy(this.gameObject);
    }
}
