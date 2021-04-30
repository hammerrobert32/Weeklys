using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weeklys.Models;
using Weeklys.Services;

namespace Weeklys.WebMVC.Controllers
{
    [Authorize]
    public class MoneyFlowController : Controller
    {
        // GET: MoneyFlow
        public ActionResult Index()
        {
            var service = CreateMoneyFlowService();
            var model = service.GetMoneyFlows();

            return View(model);
        }

        //Get view for creating a MoneyFlow
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyFlowCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMoneyFlowService();

            if (service.CreateMoneyFlow(model))
            {
                TempData["SaveResult"] = "Your MoneyFlow was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "MoneyFlow could not be created.");

            return View(model);
        }

        public ActionResult Details(int ID)
        {
            var svc = CreateMoneyFlowService();
            var model = svc.GetMoneyFlowByID(ID);

            return View(model);
        }

        //Helper method
        private MoneyFlowService CreateMoneyFlowService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MoneyFlowService(userID);
            return service;
        }
    }
}