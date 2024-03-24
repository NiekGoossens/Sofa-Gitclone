using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Done : IBacklogItemState {
        public void nextStep(BacklogItem item, UserDecorator user) {
            Console.WriteLine("Item is already done");
        }

        public void previousStep(BacklogItem item, UserDecorator user) {
            item.State = new Tested(item);
        }

        public void CreateDiscussion(string name, string description, UserDecorator user) {
            Console.WriteLine("Cannot create discussions for finished items");
        }

        public void CreateComment(int discussionNumber, Comment comment, UserDecorator user) {
            Console.WriteLine("Cannot create comments for finished items");
        }
    }
}
