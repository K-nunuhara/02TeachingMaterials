using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimalStates;

public abstract class Animal : LivingEntity
{
    public bool isMovable = true;
    public string uid = System.Guid.NewGuid().ToString();
    public string momUid = null;
    public AnimalGene gene;
    public IAnimalState state;
    public AnimalStats stats;
    public AudioSource sound;

    public void ChangeState(IAnimalState state)
    {
        this.state = state;
    }

    public void MakeSound()
    {
        if (sound != null)
        {
            this.sound.Play();
        }
    }
}
