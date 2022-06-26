using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class MeleeAttack : Task {
        private Enemy enemy;
        
        private PlayerController target;

        public MeleeAttack(Enemy enemy, PlayerController target) {
            this.enemy = enemy;
            this.target = target;
        }
        
        public override Result Run() {
            if (!enemy.ReadyForAttack())
                return Result.Failure;
                
            enemy.AttackPlayer();
            return Result.Success;
            
        }
    }
}