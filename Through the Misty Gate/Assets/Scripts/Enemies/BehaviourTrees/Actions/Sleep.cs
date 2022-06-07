using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    
    public class Sleep : Task {
        private Enemy enemy;

        private GameObject target;

        public Sleep(Enemy enemy, GameObject target) {
            this.enemy = enemy;
            this.target = target;
        }

        public override Result Run() {
            if (Vector3.Distance(enemy.transform.position, this.target.transform.position) <= enemy.GetAwakenDistance()) {
                return Result.Success;
            }

            return Result.Running;
        }
    }
}