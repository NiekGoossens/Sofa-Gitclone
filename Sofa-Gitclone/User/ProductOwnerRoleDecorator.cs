using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class ProductOwnerRoleDecorator : RoleDecorator {


        public ProductOwnerRoleDecorator(User user, Project project) : base(user, project) {
            this.CanDeploy = true;
            this.CanMarkAsDone = true;
        }

        public override void Update() {
            Console.WriteLine("Product Owner " + user.Name + " has been notified");
        }


    }
}
