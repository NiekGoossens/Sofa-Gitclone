using Sofa_Gitclone.Sprint.BacklogStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint {
    public class BacklogItem {
        public string Title { get; set; }
        public string Description { get; set; }
        public int storypoints { get; set; }
        public List<string> Members { get; set; }
        public IBacklogItemState State { get; set; }

        public BacklogItem(string title, string description, int storypoints, List<string> members) {
            Title = title;
            Description = description;
            this.storypoints = storypoints;
            Members = members;
            State = new ToDo();
        }

        public void nextStep() {
            State.nextStep(this);
        }

        public void previousStep() {
            State.previousStep(this);
        }
    }
}
