using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Warning happns but it can be ignored.
    // If you want to avoid it, add "new" before string
    protected new string name;

    // Full type of getter/setter will be used on name and HP.
    protected int HP;

    // Abbreviated style of getter/setter will be used on ATK and SPD.
    protected int ATK { get; set; }
    protected int SPD { get; set; }

    // Declare constants
    private const int MAX_NAME_LENGTH = 10;
    private const int MIN_NAME_LENGTH = 2;
    private const int MAX_HP = 20;
    private const int MIN_HP = 0;
    private string ERR_MSG_NAME = 
        $"Name length must be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH}";

    // Getter for name
    public string GetName()
    {
        return this.name;
    }

    // Setter for name
    public void SetName(string name)
    {
        if (name.Length > MAX_NAME_LENGTH || name.Length < MIN_NAME_LENGTH)
            throw new System.Exception(ERR_MSG_NAME);
        else
            this.name = name;
    }

    // Getter for HP
    public int GetHP()
    {
        return this.HP;
    }

    // Setter for HP
    public void SetHP(int HP)
    {
        if (HP > MAX_HP)
            this.HP = MAX_HP;
        else if (HP < MIN_HP)
            this.HP = MIN_HP;
        else
            this.HP = HP;
    }

    // Declare abstract methods
    public abstract void Attack();
    public abstract void Die();

    // Implement normal public method
    public void Move()
    {
        MoveAction();
    }

    // Implement private method for Move()
    private void MoveAction()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
    }
}
