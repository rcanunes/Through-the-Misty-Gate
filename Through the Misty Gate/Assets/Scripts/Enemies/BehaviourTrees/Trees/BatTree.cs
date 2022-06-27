using Enemies.BehaviourTrees.Implementation;
using Enemies.BehaviourTrees.Actions;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class BatTree : Sequence {
        public BatTree(Enemy enemy, PlayerController player) {
            this.children = new List<Task>() {
                // Move randomly/patrol
                // Spot player
                // Chase player
                // Melee attack player
                
                new Sleep(enemy, player),
                new RandomMove(enemy, player),
                new PursuePlayer(enemy, player),
                new MeleeAttack(enemy, player)
            };
        }
    }
}