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

        public float rayScale = 1.0f;
        public RaycastHit hit;

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
                bool isStraightRayTouchSomething = CheckStraight(mover);
                bool isDiagnallyDownwardRayTouchWater = CheckDiagnallyDownward(mover);

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

        private bool CheckStraight(Animal mover)
        {
            Ray straightRay = new Ray(mover.GetComponent<Renderer>().bounds.center, mover.transform.forward);
            Debug.DrawRay(straightRay.origin, straightRay.direction * mover.transform.localScale.z * rayScale, Color.green, 2);
            return Physics.Raycast(straightRay, out hit, mover.transform.localScale.z * rayScale);
        }

        private bool CheckDiagnallyDownward(Animal mover)
        {
            Ray diagnallyDownwardRay = new Ray(mover.GetComponent<Renderer>().bounds.center, mover.transform.forward - mover.transform.up / 2);
            Debug.DrawRay(diagnallyDownwardRay.origin, diagnallyDownwardRay.direction * mover.transform.localScale.z * rayScale, Color.red, 2);
            int waterLayerMask = LayerMask.GetMask("Water"/*Layers.Name.Water.ToString()*/);
            return Physics.Raycast(diagnallyDownwardRay, out hit, mover.transform.localScale.z * rayScale, waterLayerMask);
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
            Debug.Log("Normal action");
        }
    }
}
