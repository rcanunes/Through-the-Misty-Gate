using System;
using Enemies.EnemyTypes;
using UnityEngine;

namespace Enemies.Projectiles {
    public class Projectile : MonoBehaviour {
        private int Damage;
        private float Speed;

        private Enemy Parent;

        private PlayerController Player;

        private Rigidbody2D RigidBody;
        
        private void Start() {
            Player = GameObject.FindObjectOfType<PlayerController>();
            
            RigidBody = GetComponent<Rigidbody2D>();
        }

        public void SetDamage(int damage) {
            Damage = damage;
        }

        public void SetSpeed(float speed) {
            Speed = speed;
        }
        
        public void SetParent(Enemy enemy) {
            Parent = enemy;
        }

        public void Launch(Vector3 origin, Vector3 target) {
            
            Vector3 direction = (target - origin).normalized;

            transform.position = origin;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            
            RigidBody.velocity = new Vector2(direction.x * Speed, direction.y * Speed);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player"))
                Player.BeAttacked(Parent, Damage);
            else if (!other.gameObject.CompareTag("Enemy"))
                Destroy(gameObject);
        }
    }
}