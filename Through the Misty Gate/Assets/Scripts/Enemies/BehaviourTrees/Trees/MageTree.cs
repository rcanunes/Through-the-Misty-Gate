using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;
using System.Collections.Generic;
using Enemies.BehaviourTrees.Actions;
using UnityEngine;

namespace Enemies.BehaviourTrees.Trees {
    public class MageTree : Sequence {
        public MageTree(Enemy enemy, PlayerController player) {
            this.children = new List<Task>() {
                // Meditate/slow patrol
                // Spot player
                // Cast buff spell on self, if no buff is present
                // Cast attack spell 1
                // Cast attack spell 2
                
                /*
                new Sleep(enemy, player),
                new CastBuffSpell(enemy),
                new CastAttackSpell(enemy, ),
                new CastAttackSpell(enemy, )*/
            };
        }
    }
}