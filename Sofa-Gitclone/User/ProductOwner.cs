using Sofa_Gitclone.observer.NotificationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.User {
    public class ProductOwner : UserDecorator {


        public ProductOwner(User user, Project project, INotification notificationPrefference) : base(user, project, notificationPrefference) {
            this.CanDeploy = true;
            this.CanMarkAsDone = true;
        }

        public override void Update(string message) {
            Console.WriteLine(message);
        }


    }
}
