﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint {
    public class DeploymentSprintFactory : ISprintFactory {

        public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate) {
            return new DeploymentSprint(name, startDate, endDate);
        }
    }
}
