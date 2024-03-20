using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class RoleDecorator {
        protected User user;

        public bool CanTest;
        public bool CanDeploy;
        public bool CanMarkAsDone;

        protected Project project;

        public RoleDecorator(User user, Project project) {
            this.user = user;
            this.project = project;
            CanTest = false;
            CanDeploy = false;
            CanMarkAsDone = false;
        }

        //public bool canTest() {
        //    return false;
        //}

        //public bool canDeploy() {
        //    return false;
        //}

        //public bool canMarkAsDone() {
        //    return false;
        //}
    }
}
