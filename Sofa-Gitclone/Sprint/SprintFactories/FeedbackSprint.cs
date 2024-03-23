using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories
{
    public class FeedbackSprint : Sprint
    {
        protected bool IsReviewing;

        public FeedbackSprint(string name, DateTime startDate, DateTime endDate, Project project) : base(name, startDate, endDate, project)
        {
        }

        public void StartReview() {
            this.IsReviewing = true;
        }

        public void EndReview() {
            this.IsReviewing = false;
        }
    }
}
