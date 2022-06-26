using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    
    public class Sleep : Task {
        private Enemy enemy;

        private PlayerController player;

        public Sleep(Enemy enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            if (Vector3.Distance(enemy.transform.position, this.player.transform.position) <= enemy.GetAwakenDistance()) {
                return Result.Success;
            }

            return Result.Running;
        }
    }
}