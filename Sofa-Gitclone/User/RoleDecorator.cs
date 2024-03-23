using Sofa_Gitclone.observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class RoleDecorator : ISubscriber {
        protected User user;

        public bool CanTest;
        public bool CanDeploy;
        public bool CanMarkAsDone;

        // notification group met case

        protected Project project;

        public RoleDecorator(User user, Project project) {
            this.user = user;
            this.project = project;
            CanTest = false;
            CanDeploy = false;
            CanMarkAsDone = false;
        }

        public virtual void Update() {
            Console.WriteLine("User " + user.Name + " has been notified");
        }
    }
}
