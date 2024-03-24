
using Sofa_Gitclone.observer;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sofa_Gitclone.Adapter;
using Sofa_Gitclone.Sprint;


namespace Sofa_Gitclone {
    public class Project {
        public string Name { get; set; }
        public List<ISubscriber>? Users { get; set; }
        public ISubscriber ProductOwner { get; set; }
        private GitAdapter _gitAdapter;

        public Project(string name) {
            this.Name = name;
            _gitAdapter = new GitAdapter();
        }

        public void AddProductOwner(ISubscriber productOwner) {
            this.ProductOwner = productOwner;
        }

        public void AddUser(ISubscriber user) {
            this.Users.Add(user);
        }

        public void Commit(BacklogItem backlogItem) {
            _gitAdapter.Commit(backlogItem);
        }
    }
}
