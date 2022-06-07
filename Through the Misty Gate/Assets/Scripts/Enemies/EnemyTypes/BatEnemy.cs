using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class BatEnemy : Enemy {
        protected override void Start() {
            base.Start();

            this.BehaviourTree = new BatTree();
        }
    }
}