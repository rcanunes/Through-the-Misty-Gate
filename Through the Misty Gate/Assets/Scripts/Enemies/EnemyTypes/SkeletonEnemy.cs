using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class SkeletonEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Walking;
            this.canJump = false;
            this.isFlying = false;

            this.BehaviourTree = new SkeletonTree(this, Player);
        }
    }
}