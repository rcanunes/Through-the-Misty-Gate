﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemies.BehaviourTrees.Implementation {
    public class Task {
        public enum Result { Running, Failure, Success} 
        
        public Task() { }

        public virtual Result Run() {
            return Result.Failure;
        }

    }
}
