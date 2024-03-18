using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class ReadyForTesting : IBacklogItemState {
        public void nextStep(BacklogItem item) {
            item.State = new Tested();

            // mag alleen door een tester gedaan worden
        }

        public void previousStep(BacklogItem item) {
            item.State = new ToDo();
        }
    }
}
