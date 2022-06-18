using System;
using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Player;

namespace Enemies.EnemyTypes {
    public abstract class Enemy : MonoBehaviour {
        
        // Basic attributes
        protected string Name;
        protected string Type;

        protected int Health;
        
        // Attack attributes
        protected int Damage;
        protected float MeleeAttackRange;
        protected float RangedAttackRange;
        protected bool hasRangedAttack = false;
        
        // Movement Style
        public enum _MovementStyle {Walking, Flying, Hopping, Immobile}
        
        // Movement attributes
        protected float Speed;
        protected _MovementStyle MovementStyle;

        // Jump attributes
        protected float JumpPower;
        protected float MaxFallingSpeed;
        protected bool canJump;
        protected bool isGrounded;
        protected bool isFlying;
        
        // Distance attributes
        protected float AwakenDistance;
        protected float BreakOffDistance;
        
        // Feet
        public Transform Feet;
        protected float CheckRadius = 0.2f;
        public LayerMask whatIsGround;   // Baby don't hurt me

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
        }

        protected void FixedUpdate() {
            //AnimationSetup();
            isGrounded = Physics2D.OverlapCircle(Feet.position, CheckRadius, whatIsGround);
            this.BehaviourTree.Run();

            if (!isFlying && !isGrounded) {
                if (RigidBody.velocity.y < 0 && RigidBody.velocity.y > MaxFallingSpeed)
                    RigidBody.AddForce(Vector2.down);
            }
        }

        // Attack methods
        public void AttackPlayer() {
            Player.BeAttacked(this, Damage);
        }
        
        public void AttackPlayerAtRange() {
            if (hasRangedAttack) {
                //Player.BeAttacked(this, Damage);
            }
        }
        
        // Movement methods
        public void Walk(string direction) {
            if (direction == "left") {
                this.RigidBody.velocity = new Vector2(-Speed, 0);
            } else if (direction == "right") {
                this.RigidBody.velocity = new Vector2(Speed, 0);
            }
        }

        public void Jump() {
            if (canJump && isGrounded)
                RigidBody.velocity = Vector2.up * JumpPower;
        }
        
        public void Hop(string direction) {
            Debug.Log(isGrounded);
            if (isGrounded) {
                if (direction == "left") {
                    RigidBody.velocity = Vector2.left * Speed + Vector2.up * JumpPower;
                } else if (direction == "right") {
                    RigidBody.velocity = Vector2.right * Speed + Vector2.up * JumpPower;
                }
            }
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

        // Setters
        public void SetVelocity(float x, float y) {
            RigidBody.velocity = new Vector2(x, y);
        }
        
    }
}