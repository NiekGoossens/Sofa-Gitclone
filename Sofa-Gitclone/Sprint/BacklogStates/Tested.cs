using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Tested : IBacklogItemState {
        public void nextStep(BacklogItem item, RoleDecorator user) {

            if (user.CanMarkAsDone)
            {
                item.State = new Done();
            }
            // else send notification
        }

        public void previousStep(BacklogItem item, RoleDecorator user) {
            item.State = new ReadyForTesting();
        }
    }
}
