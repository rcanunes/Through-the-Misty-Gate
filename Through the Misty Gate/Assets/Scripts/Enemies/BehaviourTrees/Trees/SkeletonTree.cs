using Enemies.BehaviourTrees.Implementation;
using Enemies.BehaviourTrees.Actions;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class SkeletonTree : Sequence {
        public SkeletonTree(Enemy enemy, PlayerController player) {
            this.children = new List<Task>() {
                // Randomly walk around
                // Spot player
                // Walk towards player
                // Melee attack the player
                
                new RandomMove(enemy, player),
                new PursuePlayer(enemy, player),
                new MeleeAttack(enemy, player)
            };
        }
    }
}