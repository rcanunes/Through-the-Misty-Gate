using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class TurretEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Immobile;
            this.canJump = false;
            this.isFlying = false;
            
            this.SleepDistance = 20.0f;

            this.BehaviourTree = new TurretTree(this, Player);
        }
    }
}