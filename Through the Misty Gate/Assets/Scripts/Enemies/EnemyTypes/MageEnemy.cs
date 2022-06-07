using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public class MageEnemy  : Enemy {
        protected override void Start() {
            base.Start();

            this.BehaviourTree = new MageTree();
        }
    }
}