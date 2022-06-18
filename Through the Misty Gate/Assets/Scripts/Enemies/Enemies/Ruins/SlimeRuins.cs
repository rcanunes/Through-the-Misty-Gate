using Enemies.EnemyTypes;

namespace Enemies.Enemies.Ruins {
    public class SlimeRuins : SlimeEnemy {
        protected override void Start() {
            base.Start();

            //Set attributes
            this.Health = 100;
            this.Damage = 5;

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