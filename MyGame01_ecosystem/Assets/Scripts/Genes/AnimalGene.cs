using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGene : Gene
{
    public float mobility;
    public float power;

    public AnimalGene(Genders.Type gender)
    {
        size = 1.0f;
        diseaseResist = 1.0f;
        sense = 1.0f;
        crypsis = 1.0f;
        edibility = 1.0f;
        beauty = 1.0f;
        mutationChanve = 1.0f;
        mutationRange = 1.0f;
        this.gender = gender;
        color = Color.black;
        mobility = 1.0f;
        power = 1.0f;
    }

}
