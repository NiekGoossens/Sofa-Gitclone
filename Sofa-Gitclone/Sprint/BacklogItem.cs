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
        Publisher publisher;
        public Sprint sprint;
        public List<Activity> activities;

        public BacklogItem(string title, string description, int storypoints, ISubscriber owner, Sprint sprint) {
            this.publisher = new Publisher();
            Title = title;
            Description = description;
            this.storypoints = storypoints;
            Owner = owner;
            State = new ToDo();
            this.discussions = new List<Discussion>();
            publisher.Subscribe(this.Owner);
            this.sprint = sprint;
            this.activities = new List<Activity>();
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

        public void CreateComment(int discussionNumber, Comment comment) {
            this.discussions[discussionNumber].AddComment(comment);
        }

        public void AddActivity(string name, RoleDecorator user) {
            this.activities.Add(new Activity(name, user));
        }

        public void FinishActivity(int activityNumber) {
            this.activities[activityNumber].MarkAsDone();
        }

    }
}
