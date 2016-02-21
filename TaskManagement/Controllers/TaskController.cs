using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DomainClasses;

namespace TaskManagement.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        public ActionResult Index()
        {
            TaskRepository taskRepository = new TaskRepository();
            List<Task> list = taskRepository.getAll();
            return View(list);
        }

        //
        // GET: /Task/Details/5
        public ActionResult Details(int id)
        {
            TaskRepository taskRepository = new TaskRepository();
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
                TaskRepository taskRepository = new TaskRepository();
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
            TaskRepository taskRepository = new TaskRepository();
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
                TaskRepository taskRepository = new TaskRepository();
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
            TaskRepository taskRepository = new TaskRepository();
            taskRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
