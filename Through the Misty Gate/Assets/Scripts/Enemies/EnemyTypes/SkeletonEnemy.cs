using UnityEngine;
using Enemies.BehaviourTrees.Trees;

namespace Enemies.EnemyTypes {
    public abstract class SkeletonEnemy : Enemy {
        public AudioSource WalkingSound2;
        public AudioSource WalkingSound3;
        
        protected override void Start() {
            base.Start();
            
            WalkingSound2 = transform.Find("Walking Sound 2").GetComponent<AudioSource>();
            WalkingSound3 = transform.Find("Walking Sound 3").GetComponent<AudioSource>();

            this.MovementStyle = _MovementStyle.Walking;
            this.canJump = false;
            this.isFlying = false;
            
            this.AwakenDistance = 15.0f;
            this.BreakOffDistance = 20.0f;
            this.SleepDistance = 30.0f;

            this.BehaviourTree = new SkeletonTree(this, Player);
        }
        
        public override void Walk(string direction) {
            if (direction == "left") {
                this.RigidBody.velocity = new Vector2(-Speed * SpeedModifier, 0);
            } else if (direction == "right") {
                this.RigidBody.velocity = new Vector2(Speed * SpeedModifier, 0);
            }

            if (WalkingSoundCooldown <= 0) {
                int choice = (int) Random.Range(0, 4);
                
                switch (choice) {
                    case 0:
                        WalkingSound.PlayOneShot(WalkingSound.clip);
                        break;
                    case 1:
                        WalkingSound2.PlayOneShot(WalkingSound2.clip);
                        break;
                    case 2:
                        WalkingSound3.PlayOneShot(WalkingSound3.clip);
                        break;
                }

                WalkingSoundCooldown = 3.0f;
            }
        }
    }
}