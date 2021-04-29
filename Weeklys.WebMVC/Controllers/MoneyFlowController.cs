using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weeklys.Services;

namespace Weeklys.WebMVC.Controllers
{
    public class MoneyFlowController : Controller
    {
        // GET: MoneyFlow
        public ActionResult Index()
        {
            var service = CreateMoneyFlowService();
            var model = service.GetMoneyFlow();

            return View(model);
        }

        //Helper method
        private MoneyFlowService CreateMoneyFlowService()
        {
            var userID = Guid.Parse(User.Identity.GetUserID());
            var service = new MoneyFlowService(userID);
            return service;
        }
    }
}