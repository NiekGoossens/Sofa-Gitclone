
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sofa_Gitclone {
    public class Project {
        public string Name { get; set; }
        public Role role { get; set; }
        public User.User User { get; set; }

        public Project(string name) {
            this.Name = name;
        }

        public void AddUser(User.User user, Role role) {
            var newUser = new ContributorRoleDecorator(user, this);
            this.User = user;
        }

    }
}
