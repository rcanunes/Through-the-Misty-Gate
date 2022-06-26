using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using System.Collections.Generic;
using Bosses.Dragon;

namespace Bosses {
    public class DragonBoss : Boss {
        public class DragonBossTree : Sequence {
            public DragonBossTree(Boss boss, PlayerController player) {
                this.children = new List<Task>() {
                    new Intro(boss, player),
                    new DragonBossActionTree(boss, player),
                    new Death(boss, player)
                };
            }
            
            
            public class DragonBossActionTree : RandomSelector {
                public DragonBossActionTree(Boss boss, PlayerController player) {
                    this.children = new List<Task>() {
                        new FlyBy(boss, player),
                        new FireBreath(boss, player),
                        new FireRain(boss, player)
                    };
                }

            }
        }

        protected override void Start() {
            base.Start();

            this.BehaviourTree = new DragonBossTree(this, Player);
            
            //Set attributes
            this.MaxHealth = 5000;
            this.CurrentHealth = this.MaxHealth;
            this.ContactDamage = 150;
        }
    }
}