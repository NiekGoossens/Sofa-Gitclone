﻿using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Doing : IBacklogItemState {
        private BacklogItem _backlogItem;
        
        public Doing(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public void nextStep(BacklogItem item, UserDecorator user) {

            // Check if all activities are done
            bool UnfinishedActivity = false;

            List<Activity> activites = item.activities;
            foreach (Activity activity in activites) {
                if (!activity.IsDone) {
                    UnfinishedActivity = true;
                }
            }

            if (UnfinishedActivity) {
                Console.WriteLine("Could not go to next step since there are unfinished activities");
                return;
            } else {
                item.State = new ReadyForTesting(item);
            }

            // Send notification to testers
            var testers = item.sprint.GetTesters();
            foreach (var tester in testers) {
                tester.Update(item.Title + " is ready for testing");
            }

        }

        public void previousStep(BacklogItem item, UserDecorator user) {
            item.State = new ToDo(item);
        }

        public void CreateDiscussion(string name, string description, UserDecorator user) {
            _backlogItem.discussions.Add(new Discussion(name, description, user));
        }

        public void CreateComment(int discussionNumber, Comment comment, UserDecorator user) {
            _backlogItem.discussions[discussionNumber].AddComment(comment);
        }
    }
}
