using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone {
    public class Discussion {
        public string title;
        public string description;
        public DateTime date;
        public UserDecorator user;
        public List<Comment> comments;
        public bool isClosed;

        public Discussion(string title, string description, UserDecorator user) {
            this.title = title;
            this.description = description;
            this.date = DateTime.Now;
            this.user = user;
            this.comments = new List<Comment>();
            this.isClosed = false;
        }

        public void AddComment(Comment comment) {
            this.comments.Add(comment);
        }

        public void Close() {
            this.isClosed = true;
        }

    }
}
