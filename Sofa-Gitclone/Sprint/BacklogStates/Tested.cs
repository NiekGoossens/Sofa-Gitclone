using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class Tested : IBacklogItemState {
        public void nextStep(BacklogItem item) {
            item.State = new Done();

            // mag alleen door een lead developer gedaan worden
        }

        public void previousStep(BacklogItem item) {
            item.State = new ReadyForTesting();
        }
    }
}
