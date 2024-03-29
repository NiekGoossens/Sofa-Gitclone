﻿using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public interface IBacklogItemState {

        // stuur ook gebruiker mee om te controleren of de gebruiker de juiste rol heeft om de actie uit te voeren
        void nextStep(BacklogItem item, UserDecorator user);
        void previousStep(BacklogItem item, UserDecorator user);
        void CreateDiscussion(string name, string description, UserDecorator user);
        void CreateComment(int discussionNumber, Comment comment, UserDecorator user);
    }


}
