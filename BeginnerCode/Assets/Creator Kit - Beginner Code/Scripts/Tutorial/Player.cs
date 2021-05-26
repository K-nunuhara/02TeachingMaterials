using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Constructor
    Player(string name, int HP, int ATK, int SPD)
    {
        // Using normal setter
        SetName(name);
        SetHP(HP);

        // Using abbreviated style of setter
        this.ATK = ATK;
        this.SPD = SPD;
    }

    // Abstract methods will be wrote automatically by Visual Studio.
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Attack(int ATK)
    {
        throw new System.NotImplementedException();
    }

    // Override Die method.
    public override void Die()
    {
        // Delete this object.
        Destroy(this.gameObject);
    }

    void Start()
    {
        // Warning happns when use this constractor but it can be ignored.
        // MonoBehaviour inherited class should not use "new" but this is sample.
        Player p = new Player("MikeMoose", 999, 5, 5);

        // Use getters
        Debug.Log(p.GetName());
        Debug.Log(p.GetHP());
        Debug.Log(p.ATK);
        Debug.Log(p.SPD);
    }

    void Update()
    {
        // Use method of parent calss.
        this.Move();
    }
}
