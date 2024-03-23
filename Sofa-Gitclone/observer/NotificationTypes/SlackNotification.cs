using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.observer.NotificationTypes {
    public class SlackNotification : INotification {
        public void SendNotification(string message) {
            Console.WriteLine("Slack notification: " + message);
        }
    }
}
