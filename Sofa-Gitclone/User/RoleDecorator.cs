using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class RoleDecorator {
        protected User user;

        protected Project project;

        public RoleDecorator(User user, Project project) {
            this.user = user;
            this.project = project;
        }

        //public String getRole() {
        //    return role;
        //}

        // method om rechten op te halen? zoals mag testen of mag deployen?

        // can test
        // can deploy
        // can mark as done
    }
}
