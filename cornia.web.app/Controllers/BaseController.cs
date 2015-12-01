using cornia.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cornia.web.app.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public HasanEntities database;

        public BaseController()
        {
            database = new HasanEntities();
            
        }
    }
}