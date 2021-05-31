using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AnimalStates;

namespace AnimalStates
{
    public class Normal : MonoBehaviour, IAnimalState
    {
        public void Action(Animal mover, GameObject target)
        {
            throw new System.NotImplementedException();
        }

        public GameObject FindTarget(Animal mover)
        {
            throw new System.NotImplementedException();
        }

        public void Move(Animal mover, GameObject target)
        {
            throw new System.NotImplementedException();
        }

        public void TryToMove(Animal mover, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}
