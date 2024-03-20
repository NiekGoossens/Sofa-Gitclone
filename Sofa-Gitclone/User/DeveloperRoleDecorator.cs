using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class DeveloperRoleDecorator : RoleDecorator {
        public DeveloperRoleDecorator(User user, Project project) : base(user, project) {
        }
    }
}
