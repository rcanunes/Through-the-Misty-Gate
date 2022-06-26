using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class TurretCave : TurretEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 100;
            this.CurrentHealth = this.MaxHealth;
            this.Damage = 120;

            this.AwakenDistance = 20.0f;
            this.RangedAttackRange = 0.0f;
        }
    }
}