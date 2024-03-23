using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public interface ISprintFactory
    {

        public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate, Project project);
    }
}
