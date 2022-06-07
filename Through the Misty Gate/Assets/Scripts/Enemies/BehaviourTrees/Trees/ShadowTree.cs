using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class ShadowTree : Sequence {
        public ShadowTree() {
            this.children = new List<Task>() {
                // Be invisible
                // Spot player within range
                // Fade in to reality
                // Approach player
                // Melee attack player
                // If hit, temporarily fade out
            };
        }
    }
}