using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class SlimeCave : SlimeEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 250;
            this.CurrentHealth = this.MaxHealth;
            this.Damage = 200;

            this.Speed = 2.0f;
            this.JumpPower = 5.0f;
            this.MaxFallingSpeed = 5.0f;

            this.AwakenDistance = 20.0f;
            this.BreakOffDistance = 40.0f;
            this.MeleeAttackRange = 2.0f;
            this.RangedAttackRange = 0.0f;
        }
    }
}