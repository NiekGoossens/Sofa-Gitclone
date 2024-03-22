using Sofa_Gitclone.observer;
using Sofa_Gitclone.Sprint.BacklogStates;
using Sofa_Gitclone.User;
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
        public IBacklogItemState State { get; set; }
        public ISubscriber Owner { get; set; }
        public List<Discussion> discussions;

        public BacklogItem(string title, string description, int storypoints, ISubscriber owner) {
            Title = title;
            Description = description;
            this.storypoints = storypoints;
            Owner = owner;
            State = new ToDo();
            this.discussions = new List<Discussion>();
        }

        public void nextStep(RoleDecorator user) {
            State.nextStep(this, user);
        }

        public void previousStep(RoleDecorator user) {
            State.previousStep(this, user);
        }

        public void CreateDiscussion(string name, string description, RoleDecorator user) {
            this.discussions.Add(new Discussion(name, description, user));
        }
    }
}
