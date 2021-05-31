using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalStates
{
    public interface IAnimalState
    {
        public GameObject FindTarget(Animal mover);
        public void TryToMove(Animal mover, GameObject target);
        public void Move(Animal mover, GameObject target);
        public void Action(Animal mover, GameObject target);
    }
}
