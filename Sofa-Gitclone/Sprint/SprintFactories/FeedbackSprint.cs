using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.SprintFactories {
    public class FeedbackSprint : Sprint {
        public bool IsReviewing;
        public string? Review;
        public bool FinishedSprint;

        public FeedbackSprint(string name, DateTime startDate, DateTime endDate, Project project) : base(name, startDate, endDate, project) {
            this.FinishedSprint = false;
        }

        public void StartReview() {
            this.IsReviewing = true;
        }

        public void UploadReview(string review) {
            this.Review = review;
        }

        public void EndReview() {
            if (this.Review != null) {
                this.IsReviewing = false;
                this.IsFinished = true;
            } else {
                Console.WriteLine("Could not end review as no review has been uploaded yet");
            }
        }
    }
}
