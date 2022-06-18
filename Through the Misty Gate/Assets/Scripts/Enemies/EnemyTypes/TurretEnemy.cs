using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class TurretEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Immobile;
            this.canJump = false;

            this.BehaviourTree = new TurretTree();
        }
    }
}