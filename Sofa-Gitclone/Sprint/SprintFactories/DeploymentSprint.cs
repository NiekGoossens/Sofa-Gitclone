using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public class DeploymentSprint : Sprint
    {
        public DeploymentSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
        {
        }
    }
}
