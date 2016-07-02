using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DomainClasses;
using TaskManagement.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace TaskManagement.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            TeamRepository teamRepository = TeamRepository.getInstance();
            var team=teamRepository.getTeamForUser(User.Identity.GetUserId());
            return View(team);
        }

        

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(Team team)
        {
            try
            {
                // TODO: Add insert logic here
                TeamRepository teamRepository = TeamRepository.getInstance();
                teamRepository.create(User.Identity.GetUserId(), team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            TeamRepository teamRepository = TeamRepository.getInstance();
            var search=teamRepository.search(id);
            return View(search);
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Team team)
        {
            try
            {
                // TODO: Add update logic here

                TeamRepository teamRepository = TeamRepository.getInstance();
                teamRepository.edit(team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Edit/5
        public ActionResult Invite()
        {
            return View();
        }

        // POST: Team/Edit/5
        [HttpPost]
        public async Task<ActionResult> Invite(InviteTeamMemberModel invite)
        {//coffeefactory2016
            try
            {
                TeamRepository teamRepository = TeamRepository.getInstance();
                var team=teamRepository.getTeamForUser(User.Identity.GetUserId());

                var url = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Headers["Host"] + "/Home/Register?teamid=" + team.Id;

                var body = "<p>You are invited to join team {0} on the Task Management app.</p><p>Please use the following link to register: {1}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(invite.email));   
                message.From = new MailAddress("taskmanagement2016@gmail.com"); 
                message.Subject = "Invite to join team on Task Management";
                message.Body = String.Format(body, team.Name, url); 
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "taskmanagement2016@gmail.com",  
                        Password = "coffeefactory2016"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
