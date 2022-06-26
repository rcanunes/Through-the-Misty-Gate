using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Bosses.Dragon {
    public class FlyBy : Task {
        private Boss enemy;
        
        private PlayerController player;

        public FlyBy(Boss enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            return Result.Running;
        }
    }
}