using System;
using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Random = System.Random;

namespace Enemies.EnemyTypes {
    public abstract class Enemy : MonoBehaviour {
        
        // Basic attributes
        protected string Name;
        protected string Type;

        // Health attributes
        protected int MaxHealth;
        protected int CurrentHealth;
        
        // Attack attributes
        protected int Damage;
        protected float MeleeAttackRange;
        protected float RangedAttackRange;
        protected bool hasRangedAttack = false;
        protected float AttackSpeed;
        protected float AttackCooldown;
        
        // Movement Style
        public enum _MovementStyle {Walking, Flying, Hopping, Immobile}
        
        // Movement attributes
        protected float Speed;
        protected float SpeedModifier = 1.0f;
        protected _MovementStyle MovementStyle;
        protected float RandomMoveCooldown;

        // Jump attributes
        protected float JumpPower;
        protected float MaxFallingSpeed;
        protected bool canJump;
        protected bool isGrounded;
        protected bool isFlying;
        
        // Distance attributes
        protected float AwakenDistance;
        protected float BreakOffDistance;
        protected float SleepDistance;
        
        // Feet
        public Transform Feet;
        protected float CheckRadius = 0.2f;
        public LayerMask whatIsGround;   // Baby don't hurt me
        
        // Audio
        public AudioSource WalkingSound;
        public AudioSource JumpingSound;
        public AudioSource AttackSound;
        public AudioSource DeathSound;
        protected float WalkingSoundCooldown = 3.0f;

        // Player and Manager
        protected PlayerController Player { get; private set; }
        protected GameManager Manager { get; private set; }

        // Rigidbody
        protected Rigidbody2D RigidBody;
        
        // Behaviour Tree
        protected Task BehaviourTree;
        
        protected virtual void Start() {
            this.Name = this.transform.gameObject.name;
            this.Type = this.transform.gameObject.tag;
            
            Manager = GameObject.FindObjectOfType<GameManager>();
            Player = GameObject.FindObjectOfType<PlayerController>();
            
            RigidBody = GetComponent<Rigidbody2D>();
            
            // Set audio sources
            WalkingSound = transform.Find("Walking Sound").GetComponent<AudioSource>();
            JumpingSound = transform.Find("Jumping Sound").GetComponent<AudioSource>();
            AttackSound = transform.Find("Attack Sound").GetComponent<AudioSource>();
            DeathSound = transform.Find("Death Sound").GetComponent<AudioSource>();
        }

        protected void FixedUpdate() {
            
            //AnimationSetup();
            isGrounded = Physics2D.OverlapCircle(Feet.position, CheckRadius, whatIsGround);
            this.BehaviourTree.Run();

            if (!isFlying && !isGrounded) {
                if (RigidBody.velocity.y < 0 && RigidBody.velocity.y > MaxFallingSpeed)
                    RigidBody.AddForce(Vector2.down);
            }

            if (RandomMoveCooldown > 0) {
                RandomMoveCooldown -= Time.deltaTime;
            }
            
            if (AttackCooldown > 0) {
                AttackCooldown -= Time.deltaTime;
            }
            
            if (WalkingSoundCooldown > 0) {
                WalkingSoundCooldown -= Time.deltaTime;
            }
        }

        // Attack methods
        public void AttackPlayer() {
            Player.BeAttacked(this, Damage);
            AttackSound.PlayOneShot(AttackSound.clip);
        }
        
        public void AttackPlayerAtRange() {
            if (hasRangedAttack) {
                //Player.BeAttacked(this, Damage);
            }
        }
        
        // Movement methods
        public virtual void Walk(string direction) {
            if (direction == "left") {
                this.RigidBody.velocity = new Vector2(-Speed * SpeedModifier, 0);
            } else if (direction == "right") {
                this.RigidBody.velocity = new Vector2(Speed * SpeedModifier, 0);
            }

            if (WalkingSoundCooldown <= 0) {
                WalkingSound.PlayOneShot(WalkingSound.clip);
                WalkingSoundCooldown = 3.0f;
            }
        }

        public void Jump() {
            if (canJump && isGrounded) {
                RigidBody.velocity = Vector2.up * JumpPower;
                JumpingSound.PlayOneShot(JumpingSound.clip);
            }
        }
        
        public void Hop(string direction) {
            if (isGrounded) {
                if (direction == "left") {
                    RigidBody.velocity = Vector2.left * (Speed * SpeedModifier) + Vector2.up * JumpPower;
                } else if (direction == "right") {
                    RigidBody.velocity = Vector2.right * (Speed * SpeedModifier) + Vector2.up * JumpPower;
                }
                JumpingSound.PlayOneShot(JumpingSound.clip);
            }
        }
        
        public void Fly(Vector3 direction) {
            RigidBody.velocity = new Vector2(direction.x * Speed * SpeedModifier, direction.y * Speed * SpeedModifier);
        }
        
        // Getters
        public string GetName() {
            return Name;
        }
        
        public float GetAwakenDistance() {
            return AwakenDistance;
        }
        
        public float GetBreakOffDistance() {
            return BreakOffDistance;
        }
        
        public float GetSleepDistance() {
            return SleepDistance;
        }

        public float GetAttackRange() {
            if (hasRangedAttack)
                return RangedAttackRange;

            return MeleeAttackRange;
        }
        
        public _MovementStyle GetMovementStyle() {
            return MovementStyle;
        }

        public Vector2 GetVelocity() {
            return RigidBody.velocity;
        }

        public bool CanJump() {
            return canJump;
        }

        public bool ReadyForAttack() {
            if (AttackCooldown > 0)
                return false;

            AttackCooldown = AttackSpeed;
            return true;
        }

        public bool ReadyForRandom() {
            if (RandomMoveCooldown > 0)
                return false;

            RandomMoveCooldown = 2.0f;
            return true;
        }

        // Setters
        public void SetVelocity(float x, float y) {
            RigidBody.velocity = new Vector2(x, y);
        }

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;

            if (CurrentHealth < 0) {
                // Die
                DeathSound.PlayOneShot(DeathSound.clip);
            }
        }

        public void SetSpeedModifier(float modifier) {
            SpeedModifier -= modifier;
        }
    }
}