﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.observer {
    public interface ISubscriber {
        public void Update(string message);

    }
}
