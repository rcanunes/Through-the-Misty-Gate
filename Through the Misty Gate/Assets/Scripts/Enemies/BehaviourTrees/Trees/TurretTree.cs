using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using Enemies.BehaviourTrees.Actions;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class TurretTree : Sequence {
        public TurretTree(Enemy enemy, PlayerController player) {
            this.children = new List<Task>() {
                // Sleep
                // Spot player
                // Shoot projectiles
                new Sleep(enemy, player),
                new RangedAttack(enemy, player)
            };
        }
    }
}