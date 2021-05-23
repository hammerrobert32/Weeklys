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
    public class PaychecksController : Controller
    {
                                                                                                     // Gets LIST of Paychecks
        public ActionResult Index()
        {
            var service = CreatePaychecksService();
            var model = service.GetPaychecks();

            return View(model);
        }

                                                                                                     // Gets VIEW for creating a Paychecks
        public ActionResult Create()
        {
            return View();
        }

                                                                                                     // CREATES Paychecks to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaychecksCreate model, int moneyFlowID)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePaychecksService();

            if (service.CreatePaychecks(model, moneyFlowID))
            {
                TempData["SaveResult"] = "Your Paychecks were created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Paychecks could not be created.");

            return View(model);
        }

                                                                                                     // Gets VIEW for single Paychecks
        public ActionResult Details(int ID)
        {
            var svc = CreatePaychecksService();
            var model = svc.GetPaychecksByID(ID);

            return View(model);
        }

                                                                                                      // Gets VIEW to edit single Paychecks
        public ActionResult Edit(int ID)
        {
            var service = CreatePaychecksService();
            var detail = service.GetPaychecksByID(ID);
            var model =
                new PaychecksEdit
                {
                    PaychecksID = detail.PaychecksID,
                    Name = detail.Name,
                    AmountPaid = detail.AmountPaid,
                };
            return View(model);
        }

                                                                                                      // EDITS single Paychecks to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, PaychecksEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PaychecksID != ID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePaychecksService();

            if (service.UpdatePaychecks(model))
            {
                TempData["SaveResult"] = "Your Paychecks were updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Paychecks could not be updated.");
            return View(model);
        }

                                                                                                        // Gets VIEW to delete single Paychecks
        [ActionName("Delete")]
        public ActionResult Delete(int ID)
        {
            var svc = CreatePaychecksService();
            var model = svc.GetPaychecksByID(ID);

            return View(model);
        }

                                                                                                        // DELETES single Paychecks from database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreatePaychecksService();

            service.DeletePaychecks(ID);

            TempData["SaveResult"] = "Your Paychecks were deleted";

            return RedirectToAction("Index");
        }



                                                                                                        // Helper method
        private PaychecksService CreatePaychecksService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PaychecksService(userID);
            return service;
        }
    }
}