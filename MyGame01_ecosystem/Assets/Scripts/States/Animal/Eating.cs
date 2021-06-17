using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using AnimalStates;

namespace AnimalStates
{
    public class Eating : MonoBehaviour, IAnimalState
    {
        // Singleton
        public static Eating instance { get; private set; }

        public float eatAmount = 3000;

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
            return Hunger.instance.FindTarget(mover);
        }

        public void TryToMove(Animal mover, GameObject target)
        {
            if (mover.isMovable)
            {
                mover.isMovable = false;
                Move(mover, target);
            }
        }

        public async void Move(Animal mover, GameObject target)
        {
            Rigidbody rb = mover.GetComponent<Rigidbody>();

            if (target == null)
            {
                mover.isMovable = true;
            }
            else if ((target.transform.position - mover.transform.position).sqrMagnitude < mover.transform.localScale.sqrMagnitude)
            {
                rb.transform.Rotate(-10.0f, 0.0f, 0.0f);
                await Task.Delay(1500);
                mover.isMovable = true;
            }
            else
            {
                mover.isMovable = true;
            }
        }

        public void Action(Animal mover, GameObject target)
        {
            foreach (Species.Type diet in mover.stats.DIET)
            {
                if (target.CompareTag(diet.ToString()))
                {
                    Eat(mover, target, target.tag);
                }
            }
        }

        private void Eat(Animal mover, GameObject target, string tag)
        {
            if (target.GetComponent<Flower>().calorie <= target.GetComponent<Flower>().stats.MIN_CALORIE)
            {
                Destroy(target);
                mover.ChangeState(Normal.instance);
                mover.isMovable = true;
            }
            else
            {
                // It is not good because "Flower" is hard-coding
                if (tag == Species.Type.Flower.ToString())
                {
                    target.GetComponent<Flower>().calorie =
                        Mathf.Max(target.GetComponent<Flower>().calorie - eatAmount * Time.deltaTime, target.GetComponent<Flower>().stats.MIN_CALORIE);
                    mover.calorie = Mathf.Min(mover.calorie + eatAmount * Time.deltaTime, mover.stats.MAX_CALORIE);
                }
            }
        }

    }
}
