using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CommentRepository
    {
        public void Add(Comment comment, int taskId)
        {
            TaskRepository taskRepository = new TaskRepository();
            var task=taskRepository.Search(taskId);

            if (task == null)
            {
                return;
            }

            comment.PostedAt = DateTime.Now;
            comment.UpdatedAt = DateTime.Now;
            comment.TaskId = taskId;

            var db = new EntityFrameworkContext();
            db.CommentList.Add(comment);
            db.SaveChanges();
        }

        public List<Comment> getAll(int taskId)
        {
            TaskRepository taskRepository = new TaskRepository();
            var task = taskRepository.Search(taskId);

            if (task == null)
            {
                return null;
            }

            var db = new EntityFrameworkContext();
            var comments = (from comment in db.CommentList
                            where comment.TaskId == taskId
                            select comment).ToList();
            return comments;
        }

        public Comment Search(int id)
        {
            var db = new EntityFrameworkContext();
            var find = (from comment in db.CommentList
                        where comment.Id == id
                        select comment).FirstOrDefault();
            return find;
        }

        public void Edit(int id, Comment updatedComment)
        {
            var db = new EntityFrameworkContext();
            var original = db.CommentList.Find(id);

            if (original != null)
            {
                updatedComment.PostedAt = original.PostedAt;
                updatedComment.UpdatedAt = DateTime.Now;
                db.Entry(original).CurrentValues.SetValues(updatedComment);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var db = new EntityFrameworkContext();
            Comment comment = new Comment { Id = id };
            db.CommentList.Attach(comment);
            db.CommentList.Remove(comment);
            db.SaveChanges();
        }

        public void DeleteComments(int taskId)
        {
            var db = new EntityFrameworkContext();
            var commentsList = (from comment in db.CommentList
                        where comment.TaskId == taskId
                        select comment).ToList();
            foreach (var c in commentsList)
            {
                Delete(c.Id);
            }
        }
    }
}
