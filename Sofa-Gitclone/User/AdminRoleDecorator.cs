using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class AdminRoleDecorator : RoleDecorator {
        public AdminRoleDecorator(User user, Project project) : base(user, new Role { Name = "Admin" }, project) {
        }


    }
}
