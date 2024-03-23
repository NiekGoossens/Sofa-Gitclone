using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public class FeedbackSprint : Sprint
    {
        public FeedbackSprint(string name, DateTime startDate, DateTime endDate, Project project) : base(name, startDate, endDate, project)
        {
        }
    }
}
