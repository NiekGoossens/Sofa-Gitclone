using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Tested : IBacklogItemState {
        private BacklogItem _backlogItem;
        
        public Tested(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }
        
        public void nextStep(BacklogItem item, UserDecorator user) {

            if (user.CanTest) {
                item.State = new Done();
            }
        }

        public void previousStep(BacklogItem item, UserDecorator user) {
            item.State = new ReadyForTesting(item);
        }
        
        public void CreateDiscussion(string name, string description, UserDecorator user) {
            _backlogItem.discussions.Add(new Discussion(name, description, user));
        }

        public void CreateComment(int discussionNumber, Comment comment, UserDecorator user) {
            _backlogItem.discussions[discussionNumber].AddComment(comment);
        }
    }
}
