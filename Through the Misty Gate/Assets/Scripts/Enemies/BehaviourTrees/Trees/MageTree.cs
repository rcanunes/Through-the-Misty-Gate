using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class MageTree : Sequence {
        public MageTree() {
            this.children = new List<Task>() {
                // Meditate/slow patrol
                // Spot player
                // Cast buff spell on self, if no buff is present
                // Cast attack spell 1
                // Cast attack spell 2
            };
        }
    }
}