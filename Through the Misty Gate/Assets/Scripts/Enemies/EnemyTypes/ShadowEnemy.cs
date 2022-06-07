using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public class ShadowEnemy  : Enemy {
        protected override void Start() {
            base.Start();

            this.BehaviourTree = new ShadowTree();
        }
    }
}