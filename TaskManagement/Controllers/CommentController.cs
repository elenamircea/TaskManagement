using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagement.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comment/Create
        public ActionResult Create(int taskId)
        {
            ViewBag.taskId = taskId;
            return View();
        }

        //
        // POST: /Comment/Create
        [HttpPost]
        public ActionResult Create(int id, Comment comment)
        {
            try
            {
                CommentRepository commentRepository = new CommentRepository();
                commentRepository.Add(comment, id);

                return RedirectToAction("Details", "Task", new { id=id});
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comment/Edit/5?taskId=3
        public ActionResult Edit(int id, int taskId)
        {
            ViewBag.taskId = taskId;
            CommentRepository commentRepository = new CommentRepository();
            var comment = commentRepository.Search(id);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                CommentRepository commentRepository = new CommentRepository();
                commentRepository.Edit(id, comment);

                return RedirectToAction("Details", "Task", new { id = comment.TaskId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Comment/Delete/5
        public ActionResult Delete(int id, int taskId)
        {
            CommentRepository commentRepository = new CommentRepository();
            commentRepository.Delete(id);
            return RedirectToAction("Details", "Task", new { id = taskId });
        }
    }
}
