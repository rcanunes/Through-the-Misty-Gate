using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class SlimeEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.movementStyle = 2;
            this.canJump = true;

            this.BehaviourTree = new SlimeTree();
        }
    }
}