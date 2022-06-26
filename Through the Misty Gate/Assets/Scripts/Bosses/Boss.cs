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

            this.BehaviourTree.Run();
        }
    }
}