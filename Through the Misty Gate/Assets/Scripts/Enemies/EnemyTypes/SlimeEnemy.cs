using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class SlimeEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Hopping;
            this.canJump = false;
            this.isFlying = false;

            this.BehaviourTree = new SlimeTree(this, Player);
        }
    }
}