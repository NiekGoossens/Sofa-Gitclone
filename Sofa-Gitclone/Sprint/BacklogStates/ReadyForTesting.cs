using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class ReadyForTesting : IBacklogItemState {
        public void nextStep(BacklogItem item, RoleDecorator user) {
            //Console.WriteLine(user.CanTest);
            //Console.WriteLine(user);
            if (user.CanTest) {
                item.State = new Tested();
            }
            // else send failed notification
        }

        public void previousStep(BacklogItem item, RoleDecorator user) {
            item.State = new ToDo();
        }
    }
}
