using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class ReadyForTesting : IBacklogItemState {
        private BacklogItem _backlogItem;
        
        public ReadyForTesting(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }
        
        public void nextStep(BacklogItem item, UserDecorator user) {
            if (user.CanTest) {
                item.State = new Tested(item);
            } else {
                Console.WriteLine("User does not have the right role to test");
            }
        }

        public void previousStep(BacklogItem item, UserDecorator user) {
            item.State = new ToDo(item);
            item.sprint.project.ProductOwner.Update(item.Title + " has been moved back to ToDo");
        }
        
        public void CreateDiscussion(string name, string description, UserDecorator user) {
            _backlogItem.discussions.Add(new Discussion(name, description, user));
        }

        public void CreateComment(int discussionNumber, Comment comment, UserDecorator user) {
            _backlogItem.discussions[discussionNumber].AddComment(comment);
        }
    }
}
