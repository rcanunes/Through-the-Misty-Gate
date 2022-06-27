using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using System.Collections.Generic;
using Bosses.Dragon;

namespace Bosses {
    public class DragonBoss : Boss {
        public class DragonBossTree : Sequence {
            public DragonBossTree(DragonBoss boss, PlayerController player) {
                this.children = new List<Task>() {
                    new Intro(boss, player),
                    new DragonBossActionTree(boss, player),
                    new Death(boss, player)
                };
            }
            
            
            public class DragonBossActionTree : RandomSelector {
                public DragonBossActionTree(DragonBoss boss, PlayerController player) {
                    this.children = new List<Task>() {
                        new FlyBy(boss, player),
                        new FireBreath(boss, player),
                        new FireRain(boss, player)
                    };
                }

            }
        }

        protected AudioSource RoarSound;
        protected AudioSource WingSound;
        protected AudioSource BreathSound;
        protected AudioSource DeathSound;
        

        protected override void Start() {
            base.Start();

            BehaviourTree = new DragonBossTree(this, Player);
            
            //Set attributes
            MaxHealth = 5000;
            CurrentHealth = MaxHealth;
            ContactDamage = 150;
            
            // Set audio sources
            RoarSound = transform.Find("Roar Sound").GetComponent<AudioSource>();
            WingSound = transform.Find("Jumping Sound").GetComponent<AudioSource>();
            BreathSound = transform.Find("Attack Sound").GetComponent<AudioSource>();
            DeathSound = transform.Find("Death Sound").GetComponent<AudioSource>();
            
        }

        public void Roar() {
            RoarSound.PlayOneShot(RoarSound.clip);
        }

        public void Move() {
            // Move to other side of arena
            
            WingSound.PlayOneShot(WingSound.clip);
        }

        public void Die() {
            DeathSound.PlayOneShot(DeathSound.clip);
            
            // Die
        }
    }
}