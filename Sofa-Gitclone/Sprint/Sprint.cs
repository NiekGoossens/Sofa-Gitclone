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

        public Sprint(string name, DateTime startDate, DateTime endDate) {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public void AddBacklogItem(BacklogItem backlogItem) {
            this.backlogItems.Add(backlogItem);
        }

    }
}
