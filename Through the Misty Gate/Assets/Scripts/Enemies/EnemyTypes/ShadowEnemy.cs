using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class ShadowEnemy : Enemy {
        protected override void Start() {
            base.Start();
            
            this.movementStyle = 0;
            this.canJump = true;

            this.BehaviourTree = new ShadowTree();
        }
    }
}