using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class BatCave : BatEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 150;
            this.CurrentHealth = this.MaxHealth;
            
            this.Damage = 220;
            this.AttackSpeed = 1.0f;

            this.Speed = 4.0f;

            this.AwakenDistance = 20.0f;
            this.BreakOffDistance = 40.0f;
            this.MeleeAttackRange = 2.0f;
            this.RangedAttackRange = 0.0f;
        }
    }
}