using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class RangedAttack : Task {
        private Enemy enemy;
        
        private PlayerController player;

        public RangedAttack(Enemy enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }
        
        public override Result Run() {
            try {
                enemy.AttackPlayerAtRange();
                return Result.Success;
            }
            catch {
                return Result.Failure;
            }
        }
    }
}