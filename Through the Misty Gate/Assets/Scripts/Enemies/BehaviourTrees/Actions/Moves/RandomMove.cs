using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class RandomMove : Task {
        private Enemy enemy;
        
        private PlayerController player;

        public RandomMove(Enemy enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            if (player != null && Vector3.Distance(enemy.transform.position, this.player.transform.position) <=
                enemy.GetAwakenDistance()) return Result.Success;
            
            
            if (enemy.GetMovementStyle() == Enemy._MovementStyle.Walking) {
                var rng = Random.Range(0.0f, 1.0f);
                
                if (rng < 0.5f) {                           // Walk to the left
                    enemy.Walk("left");
                } else if (rng > 0.5f) {                    // Walk to the right
                    enemy.Walk("right");
                }
                
                if (enemy.CanJump() && (rng < 0.02f || rng > 0.98f)) {
                    enemy.Jump();
                }
                
            } else if (enemy.GetMovementStyle() == Enemy._MovementStyle.Flying) {

            } else if (enemy.GetMovementStyle() == Enemy._MovementStyle.Hopping) {
                var rng = Random.Range(0.0f, 1.0f);
                
                if (rng < 0.5f) {                           // Hop to the left
                    enemy.Hop("left");
                } else if (rng > 0.5f) {                    // Hop to the right
                    enemy.Hop("right");
                }
            }

            return Result.Running;
        }
    }
}