using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class SlimeEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.MovementStyle = _MovementStyle.Hopping;
            this.canJump = false;
            this.isFlying = false;
            
            this.AwakenDistance = 12.0f;
            this.BreakOffDistance = 16.0f;
            this.SleepDistance = 24.0f;

            this.hasRangedAttack = false;

            this.BehaviourTree = new SlimeTree(this, Player);
        }
    }
}