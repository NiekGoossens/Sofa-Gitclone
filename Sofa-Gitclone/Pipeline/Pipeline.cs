﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sofa_Gitclone.Adapter;

namespace Sofa_Gitclone.Pipeline
{
    public class Pipeline {
        private IAzureDevOps _devOps;
        
        public Pipeline() {
            _devOps = new DevOpsAdapter();
        }

        public void Run() {
            Console.WriteLine("Running pipeline");
            _devOps.Sources();
            _devOps.Package();
            _devOps.Build();
            _devOps.Test();
            _devOps.Analyze();
            _devOps.Deploy();
            _devOps.Utility();
        }
    }
}
