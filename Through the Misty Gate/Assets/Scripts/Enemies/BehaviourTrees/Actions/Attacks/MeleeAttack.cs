using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class MeleeAttack : Task {
        private Enemy enemy;
        
        private GameObject target;

        public MeleeAttack(Enemy enemy, GameObject target) {
            this.enemy = enemy;
            this.target = target;
        }
        
        public override Result Run() {
            try {
                enemy.AttackTarget(target);
                return Result.Success;
            }
            catch {
                return Result.Failure;
            }
        }
    }
}