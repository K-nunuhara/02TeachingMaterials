using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneManager : MonoBehaviour
{
    // Singleton
    public static GeneManager instance { get; private set; }

    public AnimalGene AnimalGeneInit()
    {
        return new AnimalGene(RundomGender());
    }

    public AnimalGene AnimalGeneInit(Genders.Type type)
    {
        return new AnimalGene(type);
    }

    public Gene Inherite(Gene momGene, Gene dadGene)
    {
        // TODO
        return null;
    }

    public Genders.Type RundomGender()
    {
        Genders.Type gender;
        float val = Random.Range(0f, 1f);
        if (val <= 0.50)
        {
            gender = Genders.Type.Female;
        }
        else
        {
            gender = Genders.Type.Male;
        }
        return gender;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    } // Same as template
}
