using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class RangedAttack : Task {
        private Enemy enemy;
        
        private GameObject target;

        public RangedAttack(Enemy enemy, GameObject target) {
            this.enemy = enemy;
            this.target = target;
        }
        
        public override Result Run() {
            try {
                enemy.AttackTargetAtRange(target);
                return Result.Success;
            }
            catch {
                return Result.Failure;
            }
        }
    }
}