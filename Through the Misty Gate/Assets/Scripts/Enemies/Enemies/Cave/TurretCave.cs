using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class TurretCave : TurretEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 100;
            this.CurrentHealth = this.MaxHealth;
            
            this.Damage = 250;
            this.AttackSpeed = 3.0f;
            this.RangedAttackRange = 15.0f;
        }
    }
}