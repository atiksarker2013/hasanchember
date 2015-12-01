using cornia.core;
using cornia.core.DTO;
using cornia.core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cornia.web.app.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            LogInModel model = new LogInModel();
            return View("~/Views/" + "Default" + "/Login.cshtml", model);
        }

        [HttpPost]
        public JsonResult DoLogin(LogInModel model)
        {
            LoginResult res = new LoginResult();
            UserViewModel userModel;
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                res.ResponseCode = FocusConstants.FocusResultCode.EmailOrPasswordEmpty;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.EmailOrPasswordEmpty);
                return new JsonResult() { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            res = UserService.UserLogin(model.Email, model.Password, model.RememberMe, this.database, out userModel);
            //string akey = "";
            //akey = AESCriptography.AesEncryption(userModel.aKey.ToString());
            if (res.ResponseCode == FocusConstants.FocusResultCode.Success)
            {
                res.ResultValue = 1000;
              //  res.ResponseCode = "1000";
                //var identity = new ClaimsIdentity(new[] {
                //new Claim(ClaimTypes.Name, userModel.Name),
                //new Claim(ClaimTypes.Email, userModel.EMail),
                //new Claim(ClaimTypes.GivenName, userModel.Surname),
                //new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                //new Claim(ClaimTypes.UserData, akey)
            };

                //    // Owin login
                //    var ctx = Request.GetOwinContext();
                //    var authManager = ctx.Authentication;
                //    authManager.SignIn(identity);

                //    // Set cookie
                //    CookieManager.SetOwinCookie(model.RememberMe, userModel.gKey.ToString());
                //}

                if (userModel.ChangePasswordAtNextLogon == true)
            {
                res.ResponseCode = FocusConstants.FocusResultCode.ChangePassword;
            }
            return new JsonResult() { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}