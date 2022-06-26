using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class MageEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Walking;
            this.canJump = false;
            this.isFlying = false;

            this.BehaviourTree = new MageTree(this, Player);
        }
    }
}