using UnityEngine;
using Enemies.BehaviourTrees.Implementation;
using Enemies.EnemyTypes;

namespace Enemies.BehaviourTrees.Actions {
    public class RandomMove : Task {
        private Enemy enemy;

        public RandomMove(Enemy enemy) {
            this.enemy = enemy;
        }

        public override Result Run() {
            return base.Run();
        }
    }
}