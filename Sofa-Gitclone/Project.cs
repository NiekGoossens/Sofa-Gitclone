
using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sofa_Gitclone {
    public class Project {
        public string Name { get; set; }
        public List<ISubscriber> Users { get; set; }
        public ISubscriber ProductOwner { get; set; }

        public Project(string name) {

            this.Name = name;
        }

        public void AddProductOwner(ISubscriber productOwner) {
            this.ProductOwner = productOwner;

        }

        public void AddUser(ISubscriber user) {
            this.Users.Add(user);
        }


    }
}
