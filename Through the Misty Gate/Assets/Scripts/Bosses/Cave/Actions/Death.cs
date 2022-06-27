using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Bosses.Dragon {
    public class Death : Task {
        private DragonBoss enemy;
        
        private PlayerController player;

        public Death(DragonBoss enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            if (enemy.GetHealth() <= 0) {
                enemy.Die();
                return Result.Success;
            }
            
            return Result.Running;
        }
    }
}