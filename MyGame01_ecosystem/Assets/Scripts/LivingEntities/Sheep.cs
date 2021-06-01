using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimalStates;

public class Sheep : Herbivore
{
    public Rigidbody rb = null;
    public GameObject target = null;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        ConsumeCalorie();
    }

    private void FixedUpdate()
    {

    }

    private void Initialize()
    {
        // You have to place stats.asset files into "Resources" folder
        this.stats = Resources.Load<AnimalStats>("SheepStats");
        this.age = 0;
        this.isAdult = false;
        this.health = stats.MAX_HEALTH;
        this.calorie = stats.BASE_CALORIE;
        this.water = stats.BASE_WATER;
        this.isMovable = true;
        this.state = null; // Should be set to "Normal"
        this.sound = null; // Should be set sound file
        this.rb = this.GetComponent<Rigidbody>();
        this.stats.DIET = new Species.Type[] { Species.Type.Flower, Species.Type.Grass };
    }

    public override void Ruminant()
    {
        throw new System.NotImplementedException();
    }

    public override void Grow()
    {
        throw new System.NotImplementedException();
    }

    public override void ConsumeCalorie()
    {
        throw new System.NotImplementedException();
    }

    public override void ConsumeWater()
    {
        throw new System.NotImplementedException();
    }

    public override void InTakeCalorie()
    {
        throw new System.NotImplementedException();
    }

    public override void InTakeWater()
    {
        throw new System.NotImplementedException();
    }
}


