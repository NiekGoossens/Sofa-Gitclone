﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sofa_Gitclone.Adapter;

namespace Sofa_Gitclone.Pipeline
{
    internal class Pipeline {
        private IAzureDevOps _devOps;
        
        public Pipeline() {
            _devOps = new DevOpsAdapter();
        }
    }
}
