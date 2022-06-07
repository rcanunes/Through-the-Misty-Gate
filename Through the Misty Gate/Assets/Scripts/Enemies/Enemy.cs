using UnityEngine;
using Enemies.BehaviourTrees;

namespace Enemies {
    public abstract class Enemy : MonoBehaviour {
        
        // Basic attributes
        protected string Name;
        protected string Type;

        protected int Health;
        
        // Attack attributes
        protected int Damage;
        protected float AttackRange;
        protected bool HasRangedAttack = false;
        
        // Movement attributes
        protected float Speed;
        protected float JumpPower;

        protected float AwakenDistance;

        // Player and Manager
        public GameObject Player { get; protected set; }
        public GameManager Manager { get; protected set; }

        // Rigidbody
        protected Rigidbody2D RigidBody;
        
        // Behaviour Tree
        protected Task BehaviourTree;
        
        protected virtual void Start() {
            this.Name = this.transform.gameObject.name;
            this.Type = this.transform.gameObject.tag;
            
            Manager = GameObject.FindObjectOfType<GameManager>();
            Player = GameObject.FindGameObjectWithTag("Player");
            
            RigidBody = GetComponent<Rigidbody2D>();
        }
        
        // Attack Target methods
        public void AttackTarget(GameObject target) {
            //Manager.EnemyMeleeAttack(this.gameObject, target);
        }
        
        public void AttackTargetAtRange(GameObject target) {
            if (HasRangedAttack) {
                //Manager.EnemyRangedAttack(this.gameObject, target);
            }
        }
    }
}