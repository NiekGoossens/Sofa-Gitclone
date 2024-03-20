
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
        public Publisher Publisher { get; set; }

        public Project(string name) {

            this.Name = name;
        }

        public void AddProductOwner(User.User productOwner) {

            var newUser = new ProductOwnerRoleDecorator(productOwner, this);
            ISubscriber newOwner = newUser;
            this.ProductOwner = newOwner;

        }

        public void AddUser(RoleDecorator user) {
            ISubscriber subscriber = user;
            this.Users.Add(subscriber);
        }

        public void AddTester(User.User user) {
            var newUser = new TesterRoleDecorator(user, this);
            AddUser(newUser);
        }

        public void AddDeveloper(User.User user) {
            var newUser = new DeveloperRoleDecorator(user, this);
            AddUser(newUser);
        }

        public void AddScrumMaster(User.User user) {
            var newUser = new ScrumMasterRoleDecorator(user, this);
            AddUser(newUser);
        }

    }
}
