using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class ContributorRoleDecorator : RoleDecorator {
        public ContributorRoleDecorator(User user, Project project) : base(user, new Role { Name = "Contributor" }, project) {
        }
    }
}
