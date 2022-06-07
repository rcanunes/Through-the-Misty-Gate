using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class RangedBatEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.BehaviourTree = new RangedBatTree();
        }
    }
}