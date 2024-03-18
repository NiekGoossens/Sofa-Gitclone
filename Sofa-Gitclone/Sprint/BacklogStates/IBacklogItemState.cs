using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public interface IBacklogItemState {

        // stuur ook gebruiker mee om te controleren of de gebruiker de juiste rol heeft om de actie uit te voeren
        void nextStep(BacklogItem item);
        void previousStep(BacklogItem item);
  
    }


}
