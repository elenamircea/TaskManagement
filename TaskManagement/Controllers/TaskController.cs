using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DomainClasses;
using Microsoft.AspNet.Identity;

namespace TaskManagement.Controllers
{
    public class TaskController : Controller
    {
        TaskRepository taskRepository = TaskRepository.getInstance();
        //
        // GET: /Task/
        [Authorize]
        public ActionResult Index()
        {
            
            var userId = User.Identity.GetUserId();
            List<Task> list = taskRepository.getAll(userId);
            return View(list);
        }

        //
        // GET: /Task/Details/5
        public ActionResult Details(int id)
        {
            
            var task=taskRepository.Search(id); 
            return View(task);
        }

        //
        // GET: /Task/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create
        [HttpPost]
        public ActionResult Create(Task task)
        {
            try
            {
                
                task.UserId = User.Identity.GetUserId();

                taskRepository.Add(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5
        public ActionResult Edit(int id)
        {
            
            var task = taskRepository.Search(id);
            return View(task);
            //return View(taskRepository.Search(id));
        }

        //
        // POST: /Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Task task)
        {
            try
            {
                
                taskRepository.Edit(id,task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Delete/5
        public ActionResult Delete(int id)
        {
            
            taskRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
