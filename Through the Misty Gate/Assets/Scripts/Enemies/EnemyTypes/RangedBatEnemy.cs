using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class RangedBatEnemy : Enemy {
        protected override void Start() {
            base.Start();
            
            this.MovementStyle = _MovementStyle.Flying;
            this.canJump = false;

            this.BehaviourTree = new RangedBatTree();
        }
    }
}