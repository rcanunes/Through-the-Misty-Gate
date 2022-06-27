using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class RangedBatCave : RangedBatEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 100;
            this.CurrentHealth = this.MaxHealth;
            
            this.Damage = 250;
            this.AttackSpeed = 5.0f;
            this.ProjectileSpeed = 8.0f;

            this.Speed = 4.0f;

            this.MeleeAttackRange = 0.0f;
            this.RangedAttackRange = 10.0f;
        }
    }
}