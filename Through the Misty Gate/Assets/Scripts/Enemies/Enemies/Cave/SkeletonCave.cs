using Enemies.EnemyTypes;

namespace Enemies.Enemies.Cave {
    public class SkeletonCave : SkeletonEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.MaxHealth = 400;
            this.CurrentHealth = this.MaxHealth;
            
            this.Damage = 200;
            this.AttackSpeed = 2.5f;

            this.Speed = 1.5f;
            this.JumpPower = 4.0f;
            this.MaxFallingSpeed = 5.0f;
            
            this.MeleeAttackRange = 3.0f;
            this.RangedAttackRange = 0.0f;
        }
    }
}