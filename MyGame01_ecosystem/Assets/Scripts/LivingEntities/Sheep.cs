using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimalStates;
using UnityEngine.UI;

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

        // Should be contain as CheckHealth()
        if (this.health <= this.stats.MIN_HEALTH)
        {
            Die();
        }
        else
        {
            slider.value = this.health;
        }

        if (this.state.GetType() != Eating.instance.GetType())
        {
            if (this.calorie < this.stats.BASE_CALORIE)
            {
                ChangeState(Hunger.instance);
            }
            else
            {
                ChangeState(Normal.instance);
            }
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
        //Debug.Log("UID: " + this.uid + " calorie is " + this.calorie);
        //Debug.Log("UID: " + this.uid + " health is " + this.health);
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
        target = state.FindTarget(this);
        state.TryToMove(this, target);
        state.Action(this, target);
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
        this.state = Normal.instance;
        this.sound = null; // Should be set sound file
        this.rb = this.GetComponent<Rigidbody>();
        this.stats.DIET = new Species.Type[] { Species.Type.Flower, Species.Type.Grass };
        this.gene = GeneManager.instance.AnimalGeneInit();
        this.ui = Instantiate(UIManager.instance.animalUI_HPBar, this.transform);
        this.ui.SetActive(true);
        this.slider = this.ui.transform.Find("Slider_HP").GetComponent<Slider>();
        this.slider.minValue = this.stats.MIN_HEALTH;
        this.slider.maxValue = this.stats.MAX_HEALTH;
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


