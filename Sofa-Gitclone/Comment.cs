using Sofa_Gitclone.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa_Gitclone {
    public class Comment {
        public string Content;
        public DateTime Date;
        public RoleDecorator User;
        public List<Comment> Comments;

        public Comment(string content, RoleDecorator user) {
            this.Content = content;
            this.Date = DateTime.Now;
            this.User = user;
            this.Comments = new List<Comment>();
        }

        public void AddComment(Comment comment) {
            this.Comments.Add(comment);
        }
    }
}
