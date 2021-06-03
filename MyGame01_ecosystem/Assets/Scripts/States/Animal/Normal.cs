using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AnimalStates;

namespace AnimalStates
{
    public class Normal : MonoBehaviour, IAnimalState
    {
        // Singleton
        public static Normal instance { get; private set; }

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

        public GameObject FindTarget(Animal mover)
        {
            // Normal state doesn't look for anything.
            return null;
        }

        public void TryToMove(Animal mover, GameObject target)
        {
            if (mover.isMovable)
            {
                bool isStraightRayTouchSomething = false; //CheckStraight(mover);
                bool isDiagnallyDownwardRayTouchWater = false; //CheckDiagnallyDownward(mover);

                if (isStraightRayTouchSomething || isDiagnallyDownwardRayTouchWater)
                {
                    mover.transform.Rotate(Vector3.up, Random.Range(-60.0f, 60.0f));
                }
                else if (!isStraightRayTouchSomething && !isDiagnallyDownwardRayTouchWater)
                {
                    mover.isMovable = false;
                    if (mover.momUid == null)
                    {
                        Move(mover, target);
                    }
                    else
                    {
                        // TODO: Follow the mother
                        Move(mover, target);
                    }
                }
            }
        }

        public async void Move(Animal mover, GameObject target)
        {
            Rigidbody rb = mover.GetComponent<Rigidbody>();
            rb.transform.Rotate(-10.0f, 0.0f, 0.0f);
            rb.velocity = rb.transform.forward + rb.transform.up;
            await Task.Delay(1500);
            mover.isMovable = true;
        }

        public void Action(Animal mover, GameObject target)
        {
            Debug.Log(mover.uid + ": Normal action");
        }
    }
}
