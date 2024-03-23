using Sofa_Gitclone.observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint {
    public class Activity {
        public string Name;
        public bool IsDone;
        public ISubscriber Owner { get; set; }

        public Activity(string name, ISubscriber owner) {
            this.Name = name;
            this.IsDone = false;
            this.Owner = owner;
        }

        public void MarkAsDone() {
            this.IsDone = true;
        }
    }
}
