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

        public void Notify() {
            foreach (var subscriber in subscribers) {
                subscriber.Update();
            }
        }   

        // notify admins

        // notify scrum masters

        // notify 
    }
}
