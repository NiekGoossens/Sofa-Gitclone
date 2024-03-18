﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public interface IBacklogItemState {

        // set next state
        void SetState(IBacklogItemState state);

        // description
        // leden
        // name
        // einddatum
        // list van taken
    }


}
