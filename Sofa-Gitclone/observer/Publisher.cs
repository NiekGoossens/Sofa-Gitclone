using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone.observer {
    public class Publisher {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber) {
            subscribers.Add(subscriber);
        }

        public void UnSubscribe(ISubscriber subscriber) {
            subscribers.Remove(subscriber);
        }

        public void Notify(string message) {
            foreach (var subscriber in subscribers) {
                subscriber.Update(message);
            }
        }

    }
}
