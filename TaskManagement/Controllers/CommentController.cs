using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace TaskManagement.Controllers
{
    public class CommentController : Controller
    {

        CommentRepository commentRepository = new CommentRepository();
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
                
                comment.UserId = User.Identity.GetUserId();
                UserRepository userRepository = new UserRepository();
                var currentUser = userRepository.getUser(comment.UserId);
                comment.Username = currentUser.UserName;
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
                
                var commentDB=commentRepository.Search(id);
                if(commentDB.UserId!=User.Identity.GetUserId())
                {
                    ModelState.AddModelError("", "No rights to edit this comment!");
                    return View();
                }
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
            
            var commentDB = commentRepository.Search(id);
            if (commentDB.UserId != User.Identity.GetUserId())
            {
                ModelState.AddModelError("", "No rights to delete this comment!");
                return RedirectToAction("Details", "Task", new { id = taskId });
            }
            commentRepository.Delete(id);
            return RedirectToAction("Details", "Task", new { id = taskId });
        }
    }
}
