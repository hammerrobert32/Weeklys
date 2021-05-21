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
                                                                                                                        // Gets LIST of MoneyFlows
        public ActionResult Index()
        {
            var service = CreateMoneyFlowService();
            var model = service.GetMoneyFlows();

            return View(model);
        }

                                                                                                                        // Gets VIEW for creating a MoneyFlow
        public ActionResult Create()
        {
            return View();
        }

                                                                                                                        // CREATES MoneyFlow to database
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

                                                                                                                        // Gets VIEW for single MoneyFlow
        public ActionResult Details(int ID)
        {
            var svc = CreateMoneyFlowService();
            var model = svc.GetMoneyFlowByID(ID);

            return View(model);
        }

                                                                                                                        // Gets VIEW to edit single MoneyFlow
        public ActionResult Edit(int ID)
        {
            var service = CreateMoneyFlowService();
            var detail = service.GetMoneyFlowByID(ID);
            var model =
                new MoneyFlowEdit
                {
                    MoneyFlowID = detail.MoneyFlowID,
                    Revenue = detail.Revenue,
                    Expenses = detail.Expenses,
                    TaxesSum = detail.TaxesSum,
                    Profit = detail.Profit,
                };
            return View(model);
        }

                                                                                                                        // EDITS single MoneyFLow to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, MoneyFlowEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MoneyFlowID != ID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateMoneyFlowService();

            if (service.UpdateMoneyFlow(model))
            {
                TempData["SaveResult"] = "Your MoneyFlow was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your MoneyFlow could not be updated.");
            return View(model);
        }

                                                                                                                         // Gets VIEW to delete single MoneyFlow
        [ActionName("Delete")]
        public ActionResult Delete(int ID)
        {
            var svc = CreateMoneyFlowService();
            var model = svc.GetMoneyFlowByID(ID);

            return View(model);
        }
        
                                                                                                                         // DELETES single MoneyFlow from database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreateMoneyFlowService();

            service.DeleteMoneyFlow(ID);

            TempData["SaveResult"] = "Your MoneyFlow was deleted";

            return RedirectToAction("Index");
        }



                                                                                                                         // Helper method
        private MoneyFlowService CreateMoneyFlowService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MoneyFlowService(userID);
            return service;
        }
    }
}