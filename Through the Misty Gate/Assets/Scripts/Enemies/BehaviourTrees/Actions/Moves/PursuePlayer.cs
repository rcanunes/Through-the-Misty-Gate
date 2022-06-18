using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using Player;

namespace Enemies.BehaviourTrees.Actions {
    public class PursuePlayer : Task {
        private Enemy enemy;

        private PlayerController player;

        public PursuePlayer(Enemy enemy, PlayerController player) {
            this.enemy = enemy;
            this.player = player;
        }

        public override Result Run() {
            // Break off pursuit if player goes too far
            if (player == null || Vector3.Distance(enemy.transform.position, player.transform.position) >=
                enemy.GetBreakOffDistance()) {
                enemy.SetVelocity(0, enemy.GetVelocity().y);
                return Result.Failure;
            }

            // Attack player if in range
            if (player != null && Vector3.Distance(enemy.transform.position, player.transform.position) <=
                enemy.GetAttackRange()) return Result.Success;

            if (enemy.GetMovementStyle() == Enemy._MovementStyle.Walking) {
                if (enemy.transform.position.x > this.player.transform.position.x) {                // Walk to the left
                    enemy.Walk("left");
                } else if (enemy.transform.position.x < this.player.transform.position.x) {         // Walk to the right
                    enemy.Walk("right");
                }
                
                if (enemy.CanJump()) {
                    if (enemy.transform.position.y < this.player.transform.position.y)
                        enemy.Jump();
                }
                
            } else if (enemy.GetMovementStyle() == Enemy._MovementStyle.Flying) {

                
            } else if (enemy.GetMovementStyle() == Enemy._MovementStyle.Hopping) {
                if (enemy.transform.position.x > player.transform.position.x) {                // Hop to the left
                    enemy.Hop("left");
                } else if (enemy.transform.position.x < player.transform.position.x) {         // Hop to the right
                    enemy.Hop("right");
                }
            }

            return Result.Running;
        }
    }
}