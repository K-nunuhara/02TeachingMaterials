using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantStates
{
    public interface IPlantState
    {
        public GameObject FindTarget();
        public void Action();
    }
}