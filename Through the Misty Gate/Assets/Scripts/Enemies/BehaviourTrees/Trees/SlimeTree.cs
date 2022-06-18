using Enemies.BehaviourTrees.Implementation;
using Enemies.BehaviourTrees.Actions;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemies.BehaviourTrees.Trees {
    public class SlimeTree : Sequence {
        public SlimeTree(Enemy enemy, PlayerController player) {
            this.children = new List<Task>() {
                // Random, occasional bounces
                // Spot player
                // Bounce towards player
                // Melee attack the player
                
                new RandomMove(enemy, player),
                new PursuePlayer(enemy, player),
                new MeleeAttack(enemy, player)
            };
        }
    }
}