﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.observer.NotificationTypes {
    public interface INotification {
        public void SendNotification(string message);
    }
}
