using Sofa_Gitclone.Sprint.Export;
using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.Sprint {

    public abstract class Sprint {
        public List<BacklogItem> backlogItems;
        public string name;
        public DateTime startDate;
        public DateTime endDate;
        public List<UserDecorator> users;
        public Project project;
        public bool IsFinished;
        private bool HasStarted;
        private Pipeline.Pipeline pipeline;


        public Sprint(string name, DateTime startDate, DateTime endDate, Project project) {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.users = new List<UserDecorator>();
            this.project = project;
            this.IsFinished = false;
            this.backlogItems = new List<BacklogItem>();
        }

        public bool CanPerform() {
            if (DateTime.Now > endDate) {
                Console.WriteLine("Sprint is finished, you can't perform this action");
                return false;
            }
            return true;
        }

        public void AddBacklogItem(BacklogItem backlogItem) {
            if (CanPerform())
            {
                this.backlogItems.Add(backlogItem);
            }
        }

        public void AddUser(UserDecorator user) {
            if (CanPerform())
            {
                users.Add(user);
            }

        }

        public void RemoveUser(UserDecorator user) {
            if (CanPerform()) {
                this.users.Remove(user);
            }
        }

        public void NotifyUsers(string message) {
            foreach (UserDecorator user in users) {
                user.Update(message);
            }
        }

        public Sprint GetVariables() {
            return this;
        }

        public List<UserDecorator> GetTesters() {
            return users.Where(u => u.CanTest).ToList();
        }

        public void UpdateSprint(string name, DateTime? startDate, DateTime? endDate) {
            if (!HasStarted) {
                if (name != null) {
                    this.name = name;
                }
                if (startDate != null) {
                    this.startDate = startDate.Value;
                }
                if (endDate != null) {
                    this.endDate = endDate.Value;
                }
            }
        }

        public void StartSprint() {
            this.HasStarted = true;
        }

        public void Finish(bool Succesful) {
            pipeline.Run();
            if (!Succesful)
            {
                project.ProductOwner.Update("Sprint failed deployment");
            } else {
                IsFinished = true;
                project.ProductOwner.Update("Sprint finished succesfully");
            }
        }

        // an external service will periodically call this method to check if the sprint is finished
        public void CheckSprint() {
            if (DateTime.Now > endDate) {
                Finish(false);
            }
        }

    }
}
