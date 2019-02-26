using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float attackRange = 2;

        Transform combatTarget;

        Mover mover;

        private void Start() {
            mover = GetComponent<Mover>();
        }

        private void Update() {
            if (!combatTarget) return;

            // Disable movement to check that cancelling is working both ways
            if (!isInRange)
            {
                mover.MoveTo(combatTarget.position);                
            } 
            else
            {
                mover.Cancel();
            }
            // To here
        }

        public void Attack(CombatTarget target)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            combatTarget = target.transform;
        }

        public void Cancel()
        {
            combatTarget = null;
        }

        private bool isInRange => Vector3.Distance(transform.position, combatTarget.position) < attackRange;
    }
}