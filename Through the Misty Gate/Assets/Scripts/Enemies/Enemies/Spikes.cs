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
        
        public void OnCollisionEnter2D() {
            Player.BeSpiked();
            SpikingSound.PlayOneShot(SpikingSound.clip);
        }
    }
}