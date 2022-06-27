using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Bosses.Dragon {
    public class Intro : Task {
        private DragonBoss enemy;
        
        private PlayerController player;

        public Intro(DragonBoss enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            if (player != null && Vector3.Distance(enemy.transform.position, this.player.transform.position) <=
                enemy.GetStartDistance()) {
                enemy.Roar();
                return Result.Success;
            }
            
            return Result.Running;
        }
    }
}