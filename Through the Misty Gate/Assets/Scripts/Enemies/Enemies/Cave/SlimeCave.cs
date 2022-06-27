using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class SlimeCave : SlimeEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 250;
            this.CurrentHealth = this.MaxHealth;
            
            this.Damage = 200;
            this.AttackSpeed = 1.5f;

            this.Speed = 2.5f;
            this.JumpPower = 6.0f;
            this.MaxFallingSpeed = 5.0f;
            
            this.MeleeAttackRange = 4.0f;
            this.RangedAttackRange = 0.0f;
        }
    }
}