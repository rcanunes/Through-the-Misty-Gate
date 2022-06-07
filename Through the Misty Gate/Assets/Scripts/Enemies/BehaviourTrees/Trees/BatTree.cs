using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class BatTree : Sequence {
        public BatTree() {
            this.children = new List<Task>() {
                // Move randomly/patrol
                // Spot player
                // Chase player
                // Melee attack player
            };
        }
    }
}