using UnityEngine;
using Enemies.BehaviourTrees.Implementation;

namespace Bosses {
    public abstract class Boss : MonoBehaviour {
        // Basic attributes
        protected string Name;
        protected string Type;

        // Health attributes
        protected int MaxHealth;
        protected int CurrentHealth;
        
        // Attack attributes
        protected int ContactDamage;
        
        // Distance to start fight
        protected float StartDistance;

        // Player and Manager
        protected PlayerController Player { get; private set; }
        protected GameManager Manager { get; private set; }

        // Rigidbody
        protected Rigidbody2D RigidBody;
        
        // Behaviour Tree
        protected Task BehaviourTree;
        
        protected virtual void Start() {
            Name = this.transform.gameObject.name;
            Type = this.transform.gameObject.tag;
            
            Manager = GameObject.FindObjectOfType<GameManager>();
            Player = GameObject.FindObjectOfType<PlayerController>();
            
            RigidBody = GetComponent<Rigidbody2D>();
        }

        protected void FixedUpdate() {
            //AnimationSetup();

            BehaviourTree.Run();
        }
        
        // Getters
        public int GetHealth() {
            return CurrentHealth;
        }

        public float GetStartDistance() {
            return StartDistance;
        }
    }
}