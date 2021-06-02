using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimalStates;

public class Sheep : Herbivore
{
    public Rigidbody rb = null;
    public GameObject target = null;

    public float minScale = 0.1f;
    public float maxScale = 1.0f;
    public float growSpan = 30f;
    public float soundSpan = 7f;
    public float currentTime = 0f;
    public float growRate = 0.1f;

    void Start()
    {
        Initialize();
    }

    public override void Grow()
    {
        float nextScale = Mathf.Min(this.transform.localScale.x + growRate, maxScale);
        this.transform.localScale = Vector3.one * nextScale;
        this.age++;
    }

    void Update()
    {
        ConsumeCalorie();

        if (this.health <= this.stats.MIN_HEALTH)
        {
            Die();
        }

        if (this.calorie < this.stats.BASE_CALORIE)
        {
            // Hunder class doesn't exsist now
            // ChangeState(new Hunger());
        }
        else
        {
            ChangeState(new Normal());
        }

        currentTime += Time.deltaTime;
        if (currentTime > growSpan)
        {
            currentTime = 0f;
            Grow();
        }
        if ((int)currentTime % (int)soundSpan == 0)
        {
            MakeSound();
        }
    }

    public override void ConsumeCalorie()
    {
        Debug.Log("UID: " + this.uid + " calorie is " + this.calorie);
        Debug.Log("UID: " + this.uid + " health is " + this.health);
        this.calorie = Mathf.Max(this.calorie - this.stats.CONSUME_CALORIE * Time.deltaTime, this.stats.MIN_CALORIE);
        if (this.calorie == this.stats.MIN_CALORIE)
        {
            // Damage
            this.health = Mathf.Max(this.health - Time.deltaTime, this.stats.MIN_HEALTH);
        }
        else
        {
            // Heal
            this.health = Mathf.Min(this.health + Time.deltaTime, this.stats.MAX_HEALTH);

        }
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


