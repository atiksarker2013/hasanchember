using cornia.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cornia.web.app.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Menu
        
        public PartialViewResult GetMenuList()
        {
            MenuViewModel model = new MenuViewModel();
            //model.MenuPrivilegeModelList = new List<MenuPrivilegeViewModel>();
            //List<MenuPrivilegeViewModel> menuList = new List<MenuPrivilegeViewModel>();
            //if (SessionManager.MenuSession != null)
            //{
            //    menuList = (List<MenuPrivilegeViewModel>)Session[SessionManager.MenuSession];
            //    model.MenuPrivilegeModelList = menuList;
            //}
            //else
            //{
            //    if (CurrentUser.NameIdentifier != null)
            //    {
            //        menuList = UserService.GetAllMenuByUser(CurrentUser.NameIdentifier, database);
            //        model.MenuPrivilegeModelList = new List<MenuPrivilegeViewModel>();
            //        model.MenuPrivilegeModelList = menuList;
            //        Session[SessionManager.MenuSession] = model.MenuPrivilegeModelList;
            //    }
            //}
            return PartialView("~/Views/Default/_Partial_Menu.cshtml", model);
        }
    }
}