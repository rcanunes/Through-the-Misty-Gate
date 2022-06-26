using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enemies.BehaviourTrees.Implementation;
using UnityEngine;

namespace Enemies.BehaviourTrees.Implementation {
    
    public class RandomSelector : CompositeTask {

        public RandomSelector(List<Task> tasks) : base(tasks) { }

        public RandomSelector() { }

        public override Result Run() {
            int numberOfChildren = children.Count;

            int choice = Random.Range(0, numberOfChildren);
            
            Result result = children[choice].Run();

            // Return failure only if the boss dies
            if (result == Result.Success || result == Result.Running)
                return Result.Running;

            return Result.Failure;
        }
    }
}