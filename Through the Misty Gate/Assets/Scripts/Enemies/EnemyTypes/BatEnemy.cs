using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class BatEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Flying;
            this.canJump = false;
            this.isFlying = true;
            
            this.AwakenDistance = 15.0f;
            this.BreakOffDistance = 25.0f;
            this.SleepDistance = 30.0f;
            
            this.BehaviourTree = new BatTree(this, Player);
        }
    }
}