using cornia.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cornia.web.app.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View("~/Views/" + "Default" + "/Dashboard.cshtml");
            //try
            //{
            //    UserProfileSessionDTO UserSession = null;
            //    if (this.CheckLogin(out UserSession))
            //    {
            //        return View("~/Views/" + WebTemplate + "/Dashboard.cshtml");
            //    }
            //    else
            //    {
            //        return View("~/Views/" + WebTemplate + "/Login.cshtml");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger logger = LogManager.GetLogger("ServerLogger");
            //    logger.Info("Dashboard Page Load error");
            //    logger.ErrorException("Index", ex);
            //    return View("~/Views/" + WebTemplate + "/Error.cshtml");
            //}
        }
    }
}