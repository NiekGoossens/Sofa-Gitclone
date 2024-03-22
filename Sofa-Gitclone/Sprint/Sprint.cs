using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint {

    public abstract class Sprint {
        public List<BacklogItem> backlogItems = new List<BacklogItem>();
        public string name;
        public DateTime startDate;
        public DateTime endDate;
        public List<RoleDecorator> users;


        public Sprint(string name, DateTime startDate, DateTime endDate) {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.users = new List<RoleDecorator>();
        }

        public void AddBacklogItem(BacklogItem backlogItem) {
            this.backlogItems.Add(backlogItem);
        }

        public void AddUser(RoleDecorator user) {
            users.Add(user);

        }

        public void RemoveUser(RoleDecorator user) {
            this.users.Remove(user);
        }

        public void NotifyUsers() {
            foreach (RoleDecorator user in users) {
                user.Update();
            }
        }
        
        //pipeline in sprint

    }
}
