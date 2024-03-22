using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public class FeedbackSprintFactory : ISprintFactory
    {
        public void CreateSprint()
        {

        }

        public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
        {
            return new FeedbackSprint(name, startDate, endDate);
        }
    }
}
