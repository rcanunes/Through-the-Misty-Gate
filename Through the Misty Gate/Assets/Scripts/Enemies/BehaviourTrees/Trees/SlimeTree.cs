using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class SlimeTree : Sequence {
        public SlimeTree() {
            this.children = new List<Task>() {
                // Random, occasional bounces
                // Spot player
                // Bounce towards player
                // Melee attack the player
            };
        }
    }
}