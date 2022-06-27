using System;
using Enemies.EnemyTypes;
using UnityEngine;

namespace Enemies.Enemies {
    public class Spikes : MonoBehaviour {
        protected string Name;
        protected string Type;

        public AudioSource SpikingSound;
        
        protected PlayerController Player { get; private set; }

        public void Start() {
            this.Name = this.transform.gameObject.name;
            this.Type = this.transform.gameObject.tag;
            
            Player = GameObject.FindObjectOfType<PlayerController>();
            
            // Set audio sources
            SpikingSound = transform.Find("Spiking Sound").GetComponent<AudioSource>();
        }
        
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player")) {
                Player.BeSpiked();
                SpikingSound.PlayOneShot(SpikingSound.clip);
            }
        }
    }
}