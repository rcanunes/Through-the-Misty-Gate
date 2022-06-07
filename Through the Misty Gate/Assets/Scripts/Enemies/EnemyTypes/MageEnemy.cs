using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class MageEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.movementStyle = 0;
            this.canJump = false;

            this.BehaviourTree = new MageTree();
        }
    }
}