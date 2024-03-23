using Sofa_Gitclone.observer;
using Sofa_Gitclone.observer.NotificationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class UserDecorator : ISubscriber {
        protected User user;

        public bool CanTest;
        public bool CanDeploy;
        public bool CanMarkAsDone;
        public INotification NotificationPrefference;

        // notification group met case

        protected Project project;

        public UserDecorator(User user, Project project, INotification notificationPrefference) {
            this.user = user;
            this.project = project;
            CanTest = false;
            CanDeploy = false;
            CanMarkAsDone = false;
            NotificationPrefference = notificationPrefference;
        }

        public virtual void Update(string message) {
            NotificationPrefference.SendNotification(message);
        }
    }
}
