﻿using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint.BacklogStates {
    public class ToDo : IBacklogItemState  {
        public void nextStep(BacklogItem item, ISubscriber user) {
            item.State = new Doing();

            // implement notification
        }

        public void previousStep(BacklogItem item, ISubscriber user) {
            Console.WriteLine("Item is already in the first state");
        }
    }
}
