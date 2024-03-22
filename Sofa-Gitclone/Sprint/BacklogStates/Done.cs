using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Done : IBacklogItemState {
        public void nextStep(BacklogItem item, RoleDecorator user) {
            Console.WriteLine("Item is already done");
        }

        public void previousStep(BacklogItem item, RoleDecorator user) {
            item.State = new Tested();
        }
    }
}
