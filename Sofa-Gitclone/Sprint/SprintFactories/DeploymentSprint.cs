using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public class DeploymentSprint : Sprint
    {
        protected bool IsDeploying;
        protected string SprintName;

        public DeploymentSprint(string name, DateTime startDate, DateTime endDate, Project project) : base(name, startDate, endDate, project)
        {
            this.IsDeploying = false;
            this.SprintName = name;
        }

        public void StartDeployment() {
            this.IsDeploying = true;
            // Execute pipeline
        }

        public void StopDeployment() {
            // stop deployment
        }

        public void CancelRelease() {
            project.ProductOwner.Update("Canceled release for sprint: " + this.name);
        }


    }
}
