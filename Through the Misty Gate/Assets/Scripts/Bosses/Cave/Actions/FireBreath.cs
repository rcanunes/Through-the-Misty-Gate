using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Bosses.Dragon {
    public class FireBreath : Task {
        private DragonBoss enemy;
        
        private PlayerController player;

        public FireBreath(DragonBoss enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            return Result.Running;
        }
    }
}