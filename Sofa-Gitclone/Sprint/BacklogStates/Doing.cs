using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Doing : IBacklogItemState {

        public void nextStep(BacklogItem item) {
            item.State = new ReadyForTesting();

            // implement notification
        }

        public void previousStep(BacklogItem item) {
            item.State = new ToDo();
        }
    }
}
