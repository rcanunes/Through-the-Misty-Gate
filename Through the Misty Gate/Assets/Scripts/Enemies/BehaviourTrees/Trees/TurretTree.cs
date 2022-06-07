using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class TurretTree : Sequence {
        public TurretTree() {
            this.children = new List<Task>() {
                // Sleep
                // Spot player
                // Shoot projectiles
            };
        }
    }
}