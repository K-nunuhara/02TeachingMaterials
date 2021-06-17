using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlantStates;

namespace PlantStates
{
    public class Normal : MonoBehaviour, IPlantState
    {
        // Singleton
        public static Normal instance { get; private set; }

        public void Action()
        {
            throw new System.NotImplementedException();
        }

        public GameObject FindTarget()
        {
            throw new System.NotImplementedException();
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
        }
    }
}
