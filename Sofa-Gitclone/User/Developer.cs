using Sofa_Gitclone.observer.NotificationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class Developer : UserDecorator {
        public Developer(User user, Project project, INotification notificationPrefference) : base(user, project, notificationPrefference) {

        }
    }
}
