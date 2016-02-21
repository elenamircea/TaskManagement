using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainClasses;

namespace DataLayer
{
    public class TaskRepository
    {
        public List<Task> getAll() {
            var db = new EntityFrameworkContext();
            List<Task> list = (from task in db.TaskList
                               select task).ToList();
            return list;
        }

        public void Add(Task task) {
            var db = new EntityFrameworkContext();
            task.CreatedAt = DateTime.Now;
            task.UpdatedAt = DateTime.Now;
            db.TaskList.Add(task);
            db.SaveChanges();
        }

        public Task Search(int id) {
            var db = new EntityFrameworkContext();
            var taskQuery = (from task in db.TaskList.Include("comments")//am inclus comentariile, aduce doar primitive
                             where task.Id == id
                             select task).FirstOrDefault();
            return taskQuery;
        }

        public void Edit(int id, Task updatedTask) {
            var db = new EntityFrameworkContext();
            var original = db.TaskList.Find(id);

            if (original != null)
            {
                updatedTask.CreatedAt = original.CreatedAt;
                updatedTask.UpdatedAt = DateTime.Now;
                db.Entry(original).CurrentValues.SetValues(updatedTask);
                db.SaveChanges();
            }
        }

        public void Delete(int id) {
            var db = new EntityFrameworkContext();
            Task task = new Task {Id=id };
            db.TaskList.Attach(task);
            db.TaskList.Remove(task);
            db.SaveChanges();
            CommentRepository commentRepository = new CommentRepository();
            commentRepository.DeleteComments(id);
        }
    }
}
