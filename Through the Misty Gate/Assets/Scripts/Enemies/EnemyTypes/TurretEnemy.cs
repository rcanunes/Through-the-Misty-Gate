using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class TurretEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.movementStyle = -1;
            this.canJump = false;

            this.BehaviourTree = new TurretTree();
        }
    }
}