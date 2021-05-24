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
    public class TaxesController : Controller
    {
                                                                                                              // Gets LIST of Taxes
        public ActionResult Index()
        {
            var service = CreateTaxesService();
            var model = service.GetTaxes();

            return View(model);
        }

                                                                                                              // Gets VIEW for creating a Taxes
        public ActionResult Create()
        {
            return View();
        }

                                                                                                              // CREATES Taxes to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxesCreate model, int moneyFlowID)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTaxesService();

            if (service.CreateTaxes(model, moneyFlowID))
            {
                TempData["SaveResult"] = "Your Taxes were created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Taxes could not be created.");

            return View(model);
        }

                                                                                                              // Gets VIEW for single Taxes
        public ActionResult Details(int ID)
        {
            var svc = CreateTaxesService();
            var model = svc.GetTaxesByID(ID);

            return View(model);
        }

                                                                                                              // Gets VIEW to edit single Taxes
        public ActionResult Edit(int ID)
        {
            var service = CreateTaxesService();
            var detail = service.GetTaxesByID(ID);
            var model =
                new TaxesEdit
                {
                    TaxesID = detail.TaxesID,
                    State = detail.State,
                    Federal = detail.Federal,
                };
            return View(model);
        }

                                                                                                              // EDITS single Taxes to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, TaxesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TaxesID != ID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateTaxesService();

            if (service.UpdateTaxes(model))
            {
                TempData["SaveResult"] = "Your Taxes were updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Taxes could not be updated.");
            return View(model);
        }

                                                                                                              // Gets VIEW to delete single Taxes
        [ActionName("Delete")]
        public ActionResult Delete(int ID)
        {
            var svc = CreateTaxesService();
            var model = svc.GetTaxesByID(ID);

            return View(model);
        }

                                                                                                             // DELETES single Taxes from database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreateTaxesService();

            service.DeleteTaxes(ID);

            TempData["SaveResult"] = "Your Taxes were deleted";

            return RedirectToAction("Index");
        }



                                                                                                             // Helper method
        private TaxesService CreateTaxesService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TaxesService(userID);
            return service;
        }
    }
}