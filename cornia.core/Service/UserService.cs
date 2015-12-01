using cornia.core.Data;
using cornia.core.DTO;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace cornia.core.Service
{
    public static class UserService
    {
        /// <summary>
        /// Get all user for grid
        /// </summary>
        /// <param name="database"></param>
        /// <param name="UserViewModelList"></param>
        /// <returns></returns>
        public static FocusConstants.FocusResultCode GetAllUserGrid(HasanEntities database, out List<UserViewModel> UserViewModelList)
        {
            UserViewModelList = new List<UserViewModel>();
            try
            {
                List<User> entityList = GetAllUser(database);
                if (entityList != null && entityList.Count > 0)
                {
                    foreach (User entity in entityList)
                    {
                        UserViewModelList.Add(GetUserModel(entity, database));
                    }
                }

            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetAllUserTypeGrid", ex);
                return FocusConstants.FocusResultCode.Exception;
            }
            return FocusConstants.FocusResultCode.Success;
        }

        /// <summary>
        /// Mapping user with UserViewModel
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        private static UserViewModel GetUserModel(User userEntity, HasanEntities database)
        {

            

            if (userEntity != null)
            {
                UserViewModel model = new UserViewModel();
                model.Id = userEntity.Id;
                model.gKey = userEntity.gKey;
                model.UserTypeRef = userEntity.UserTypeRef;
                model.UserTypeName = userEntity.UserType.Name;
                model.GroupCompanyRef = userEntity.GroupCompanyRef;
             
                model.EMail = userEntity.EMail;
                model.Password = userEntity.Password;
                model.PIN = userEntity.PIN;
                model.Name = userEntity.Name;
                model.Surname = userEntity.Surname;
                model.ChangePasswordAtNextLogon = userEntity.ChangePasswordAtNextLogon;
                model.MailNotification = userEntity.MailNotification;
                model.Note = userEntity.Note;
                model.Sort = userEntity.Sort;
                model.Active = userEntity.Active;
                model.Deleted = userEntity.Deleted;
                return model;
            }
            else
                return null;
        }

        /// <summary>
        /// Get all user from database
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        private static List<User> GetAllUser(HasanEntities database)
        {
            try
            {
                var UserList = database.User.Where(it => it.Deleted == false).OrderBy(it => it.Sort).ToList();
                if (UserList != null)
                    return UserList;
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetAllUser", ex);
                throw ex;

            }

        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static FocusConstants.FocusResultCode CreateUser(UserViewModel model, HasanEntities database)
        {
            try
            {

                if (DoesUserNameExist(model.EMail, database))
                    return FocusConstants.FocusResultCode.DuplicateUser;

                User entity = new User();
                entity.UserTypeRef = model.UserTypeRef;
                entity.GroupCompanyRef = model.GroupCompanyRef;
                entity.CustomerRef = model.CustomerRef;
                entity.FactoryRef = model.FactoryRef;
                entity.PersonRef = model.PersonRef;
                entity.EmployeeRef = model.EmployeeRef;
                entity.EMail = model.EMail;
                entity.Password = model.Password;
                entity.PIN = model.PIN;
                entity.Name = model.Name;
                entity.Surname = model.Surname;
                entity.ChangePasswordAtNextLogon = model.ChangePasswordAtNextLogon;
                entity.MailNotification = model.MailNotification;
                entity.Note = model.Note;
                entity.Sort = model.Sort;
                entity.Active = model.Active;
                entity.Deleted = false;
                database.User.Add(entity);
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("CreateUserType", ex);
                return FocusConstants.FocusResultCode.Exception;
            }
            return FocusConstants.FocusResultCode.Success;
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static FocusConstants.FocusResultCode UpdateUser(UserViewModel model, HasanEntities database)
        {
            try
            {
                User entity = database.User.Where(it => it.Id == model.Id).SingleOrDefault();
                entity.UserTypeRef = model.UserTypeRef;
                entity.GroupCompanyRef = model.GroupCompanyRef;
                entity.CustomerRef = model.CustomerRef;
                entity.FactoryRef = model.FactoryRef;
                entity.PersonRef = model.PersonRef;
                entity.EmployeeRef = model.EmployeeRef;
                entity.EMail = model.EMail;
                entity.Password = model.Password;
                entity.PIN = model.PIN;
                entity.Name = model.Name;
                entity.Surname = model.Surname;
                entity.ChangePasswordAtNextLogon = model.ChangePasswordAtNextLogon;
                entity.MailNotification = model.MailNotification;
                entity.Note = model.Note;
                entity.Sort = model.Sort;
                entity.Active = model.Active;
                entity.Deleted = model.Deleted;
                database.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("UpdateUserType", ex);
                return FocusConstants.FocusResultCode.Exception;
            }


            return FocusConstants.FocusResultCode.Success;
        }
        public static User SearchUser(int id, HasanEntities database)
        {
            return database.User.Where(it => it.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static FocusConstants.FocusResultCode DeleteUser(UserViewModel model, HasanEntities database)
        {
            User entity = database.User.Where(it => it.Id == model.Id).SingleOrDefault();
            entity.Deleted = true;
            database.SaveChanges();
            return FocusConstants.FocusResultCode.Success;
        }

        /// <summary>
        /// Get all user fro drop down
        /// </summary>
        /// <param name="database"></param>
        /// <param name="loadClass"></param>
        /// <returns></returns>
        public static List<UserViewModel> GetUserDropDown(HasanEntities database, bool loadClass)
        {
            try
            {
                List<UserViewModel> DTOlist = new List<UserViewModel>();
                var UserList = GetAllUser(database);
                if (UserList != null)
                {
                    foreach (User entity in UserList)
                    {
                        DTOlist.Add(GetUserDTO(entity, loadClass));
                    }
                    return DTOlist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetUserTypeDropDown", ex);
                throw ex;

            }

        }

        /// <summary>
        /// Mapping userdata to UserViewModel
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="loadClass"></param>
        /// <returns></returns>
        private static UserViewModel GetUserDTO(User entity, bool loadClass)
        {

            try
            {
                if (entity != null)
                {
                    UserViewModel model = new UserViewModel();
                    model.Id = entity.Id;
                    model.gKey = entity.gKey;
                    model.EMail = entity.EMail;
                    model.Name = entity.Name;
                    model.Note = entity.Note;
                    model.Sort = entity.Sort;
                    model.Active = entity.Active;
                    model.Deleted = entity.Deleted;
                    return model;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetUserDTO", ex);
                throw ex;

            }
        }

        /// <summary>
        /// User login from controller
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <param name="database"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static LoginResult UserLogin(string email, string password, bool rememberMe, HasanEntities database, out UserViewModel userModel)
        {
            
            userModel = new UserViewModel();

            LoginResult res = new LoginResult();
            try
            {
                User mem = database.User.Where(it => it.EMail == email && !it.Deleted).FirstOrDefault(); // get data for the user
                if (mem == null)
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.MemberNotExist;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.MemberNotExist);
                    return res;
                }
                if (mem.Password != password) // check user password is valid or not
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.InvalidPassword;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.InvalidPassword);
                    return res;
                }
                if (!mem.Active) // check user activess
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.MemberIsNotActive;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.MemberIsNotActive);
                    return res;
                }

                if (DoLogin(email, password, rememberMe, database, out userModel))
                {
                    // var p = Enum.Parse(typeof(FocusConstants.FocusResultCode), FocusConstants.FocusResultCode.Success.ToString());
                    //res.ResponseCode = (FocusConstants)Enum.Parse(typeof(FocusConstants), FocusConstants.FocusResultCode.Success);
                     res.ResponseCode = FocusConstants.FocusResultCode.Success;
                  
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Success);
                }


                return res;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("UserLogin", ex);
                res.ResponseCode = FocusConstants.FocusResultCode.Exception;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Exception);
                return res;

            }
        }


        /// <summary>
        /// Login user & keep data into session
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <param name="database"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        private static bool DoLogin(string email, string password, bool rememberMe, HasanEntities database, out UserViewModel userModel)
        {
            try
            {
                userModel = new UserViewModel();

                if (email == null || email.Trim() == "")
                    return false;
                var user = database.User.Where(it => it.EMail == email && it.Password == password && it.Active && !it.Deleted).SingleOrDefault();
                if (user != null)
                {
                    userModel.Id = user.Id;
                    userModel.Password = user.Password;
                    userModel.EMail = user.EMail;
                    userModel.Name = user.Name;
                    userModel.Surname = user.Surname;
                    userModel.gKey = user.gKey;
                    userModel.aKey = user.aKey;
                    userModel.ChangePasswordAtNextLogon = user.ChangePasswordAtNextLogon;

                    UserProfileSessionDTO sessionUser = new UserProfileSessionDTO();
                    sessionUser.EMail = user.EMail;
                    sessionUser.UserId = user.Id;
                    sessionUser.FullName = user.Name + " " + user.Surname;
                    sessionUser.isLocked = false;
                    HttpContext.Current.Session["UserSession"] = sessionUser;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("DoLogin", ex);
                throw ex;
            }

        }


        /// <summary>
        /// Get user data from session
        /// </summary>
        /// <returns></returns>
        public static UserProfileSessionDTO GetLoggedInUserSession()
        {
            try
            {
                var session = HttpContext.Current.Session;
                if (session["UserSession"] != null)
                {
                    return session["UserSession"] as UserProfileSessionDTO;
                }
                /* Create new empty session object */
                session["UserSession"] = new UserProfileSessionDTO();
                return session["UserSession"] as UserProfileSessionDTO;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetLoggedInUserSession", ex);
                throw ex;
            }

        }


        /// <summary>
        /// Login from cookie data
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool DoLogin(string username, string password, bool rememberMe, HasanEntities database)
        {
            try
            {
                if (username == null || username.Trim() == "")
                    return false;
                var user = database.User.Where(it => it.EMail == username && it.Password == password && it.Active && !it.Deleted).SingleOrDefault();

                if (user != null)
                {
                    UserProfileSessionDTO sessionUser = new UserProfileSessionDTO();
                    sessionUser.EMail = user.EMail;
                    sessionUser.UserId = user.Id;
                    sessionUser.FullName = user.Name;
                    sessionUser.Password = user.Password;
                    HttpContext.Current.Session["UserSession"] = sessionUser;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("GetLoggedInUserSession", ex);
                throw ex;
            }
        }


        /// <summary>
        /// Email forgotten password 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static ForgetPasswordResult EmailForgottenPassword(string email, HasanEntities database)
        {
            ForgetPasswordResult res = new ForgetPasswordResult();
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.EmailAddressIsNull;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.EmailAddressIsNull);
                    return res;
                }
                User mem = database.User.Where(it => it.EMail == email && !it.Deleted).FirstOrDefault();
                if (mem == null)
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.MemberNotExist;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.MemberNotExist);
                    return res;
                }
                if (!mem.Active)
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.MemberIsNotActive;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.MemberIsNotActive);
                    return res;
                }

                if (SendForgatePasswordMail(mem.EMail, mem.Password))
                {
                    res.ResponseCode = FocusConstants.FocusResultCode.Success;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Success);
                }


                return res;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("EmailForgottenPassword", ex);
                res.ResponseCode = FocusConstants.FocusResultCode.Exception;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Exception);
                return res;

            }
        }

        /// <summary>
        /// Send mail body
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool SendForgatePasswordMail(string email, string password)
        {

            string EmailBody = "Your user name: " + email + " and Password:" + password + "";
            SendSiteEmail(email, "Focus: Forget password", EmailBody);

            return true;
        }
        /// <summary>
        /// Send mail with magnifo core
        /// </summary>
        /// <param name="ReciepentEmailAddress"></param>
        /// <param name="Subject"></param>
        /// <param name="EmailBody"></param>
        /// <returns></returns>
        private static bool SendSiteEmail(string ReciepentEmailAddress, string Subject, string EmailBody)
        {
            return true;
            //if (SMTP.SendSiteEmail(ReciepentEmailAddress, Subject, EmailBody))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public static bool IsValidBarierToken(string token, HasanEntities database)
        {
            var user = database.User.Where(it => it.gKey == new Guid(token) && it.Active && !it.Deleted).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool DoesUserNameExist(string email, HasanEntities database)
        {
            if (database.User.Where(it => it.EMail == email && !it.Deleted).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       


        /// <summary>
        /// Match Password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="userId"></param>
        /// <param name="database"></param>
        /// <returns>boolean</returns>
        private static bool IsMatchPassword(string oldPassword, int userId, HasanEntities database)
        {
            User entity = database.User.FirstOrDefault(it => it.Id == userId & it.Password == oldPassword);
            return entity != null;
        }

        /// <summary>
        /// Match Password
        /// </summary>
        /// <param name="oldPIN"></param>
        /// <param name="userId"></param>
        /// <param name="database"></param>
        /// <returns>boolean</returns>
        private static bool IsMatchPIN(string oldPIN, int userId, HasanEntities database)
        {
            User entity = database.User.FirstOrDefault(it => it.Id == userId & it.PIN == oldPIN);
            return entity != null;
        }

        
        /// <summary>
        /// Change Next login password
        /// </summary>
        /// <param name="PIN"></param>
        /// <param name="userId"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static ProfileResult ChangeNextLoginPassrord(string OldPassword, string NewPassword, string ConfirmPassrord, int userId, HasanEntities database)
        {

            ProfileResult res = new ProfileResult();

            if (string.IsNullOrEmpty(OldPassword))
            {
                res.ResponseCode = FocusConstants.FocusResultCode.OldPasswordEmpty;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.OldPasswordEmpty);
                return res;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                res.ResponseCode = FocusConstants.FocusResultCode.NewPasswordEmpty;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.NewPasswordEmpty);
                return res;
            }
            if (string.IsNullOrEmpty(ConfirmPassrord))
            {
                res.ResponseCode = FocusConstants.FocusResultCode.ConfirmPasswordEmpty;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.ConfirmPasswordEmpty);
                return res;
            }
            else if (!IsMatchPassword(OldPassword, userId, database))
            {
                res.ResponseCode = FocusConstants.FocusResultCode.InvalidOldPassword;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.InvalidOldPassword);
                return res;
            }
            else if (NewPassword != ConfirmPassrord)
            {
                res.ResponseCode = FocusConstants.FocusResultCode.NewAndConfirmPasswordMissmatch;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.NewAndConfirmPasswordMissmatch);
                return res;
            }
            else
            {

                //Regex regex = new Regex(@"" + Core.GlobalProperty.FocusConfUserPasswordFormat);
                //Match match = regex.Match(NewPassword);
                //if (!match.Success)
                //{
                //    res.ResponseCode = FocusConstants.FocusResultCode.InvalidPasswordFormat;
                //    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.InvalidPasswordFormat);
                //    return res;
                //}
            }
            try
            {
                User entity = database.User.Where(it => it.Id == userId).SingleOrDefault();
                entity.Password = NewPassword;
                entity.ChangePasswordAtNextLogon = false;
                database.SaveChanges();
                res.ResponseCode = FocusConstants.FocusResultCode.PasswordChangeSuccess;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.PasswordChangeSuccess);
                return res;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("ChangePassword", ex);
                res.ResponseCode = FocusConstants.FocusResultCode.Exception;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Exception);
                return res;

            }
        }



        public static List<MenuPrivilegeViewModel> GetAllMenuByUser(string UserId, HasanEntities database)
        {
            List<MenuPrivilegeViewModel> menuList = new List<MenuPrivilegeViewModel>();
            int UserRefId = Convert.ToInt32(UserId);
            UserViewModel model = new UserViewModel();
            var user = database.User.Where(it => it.Id == UserRefId).SingleOrDefault();
            model.UserTypeRef = user.UserType.Id;
            List<UserTypePermission> entityList = GetAllUserTypePermission(model.UserTypeRef, database);
            //var permi
            if (entityList != null && entityList.Count > 0)
            {
                foreach (UserTypePermission entity in entityList)
                {
                    menuList.Add(GetUserTypePermissionModel(entity));
                }
            }

            return menuList;
        }

        private static MenuPrivilegeViewModel GetUserTypePermissionModel(UserTypePermission entity)
        {
            MenuPrivilegeViewModel model = new MenuPrivilegeViewModel();
            model.PermissionRef = entity.PermissionRef;
            model.UserTypeRef = entity.UserTypeRef;

            return model;
        }

        private static List<UserTypePermission> GetAllUserTypePermission(int UserTypeRef, HasanEntities database)
        {
            var CurrencyList = database.UserTypePermission.Where(it => it.Denied != 0 && it.UserTypeRef == UserTypeRef).ToList();
            if (CurrencyList != null)
                return CurrencyList;
            else
            {
                return null;
            }
        }

        public static bool HasPermission(int MenuId, int UserRefId, HasanEntities database)
        {
            UserViewModel model = new UserViewModel();
            var user = database.User.Where(it => it.Id == UserRefId).SingleOrDefault();
            if (user != null)
            {
                model.UserTypeRef = user.UserType.Id;
                var UserTypePermission = database.UserTypePermission.Where(it => it.PermissionRef == MenuId && it.UserTypeRef == model.UserTypeRef).SingleOrDefault();

                if (UserTypePermission != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public static bool HasUIPermission(int MenuId, Guid UserakeyId, HasanEntities database)
        {
            UserViewModel model = new UserViewModel();
            var user = database.User.Where(it => it.aKey == UserakeyId).SingleOrDefault();
            if (user != null)
            {
                model.UserTypeRef = user.UserType.Id;
                var UserTypePermission = database.UserTypePermission.Where(it => it.PermissionRef == MenuId && it.UserTypeRef == model.UserTypeRef).SingleOrDefault();

                if (UserTypePermission != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool HasServicePermission(int MenuId, Guid Userakey, HasanEntities database)
        {
            UserViewModel model = new UserViewModel();
            var user = database.User.Where(it => it.aKey == Userakey).SingleOrDefault();
            if (user != null)
            {
                model.UserTypeRef = user.UserType.Id;
                var UserTypePermission = database.UserTypePermission.Where(it => it.PermissionRef == MenuId && it.UserTypeRef == model.UserTypeRef).SingleOrDefault();

                if (UserTypePermission != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static LoginResult UserLoginBygkey(string gkey, bool RememberMe, HasanEntities database, out UserViewModel userModel)
        {
            LoginResult res = new LoginResult();
            userModel = new UserViewModel();
            try
            {

                if (DoLoginBygkey(gkey, database, out userModel))
                {

                    res.ResponseCode = FocusConstants.FocusResultCode.Success;
                    res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Success);
                }
                return res;

            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.ErrorException("UserLoginBygkey", ex);
                res.ResponseCode = FocusConstants.FocusResultCode.Exception;
                res.ResponseMessage = FocusMessage.GetResourceResultCodeValue(FocusConstants.FocusResultCode.Exception);
                return res;
            }
        }

        private static bool DoLoginBygkey(string gkey, HasanEntities database, out UserViewModel userModel)
        {
            userModel = new UserViewModel();
            string gkeyToken="";//= AESCriptography.AesDecryption(gkey);
            Guid usergkey = new Guid(gkeyToken);


            var user = database.User.Where(it => it.gKey == usergkey && !it.Deleted).SingleOrDefault();
            if (user != null)
            {
                userModel.Id = user.Id;
                userModel.Password = user.Password;
                userModel.EMail = user.EMail;
                userModel.Name = user.Name;
                userModel.Surname = user.Surname;
                userModel.gKey = user.gKey;
                userModel.aKey = user.aKey;
                userModel.ChangePasswordAtNextLogon = user.ChangePasswordAtNextLogon;

                UserProfileSessionDTO sessionUser = new UserProfileSessionDTO();
                sessionUser.EMail = user.EMail;
                sessionUser.UserId = user.Id;
                sessionUser.FullName = user.Name + " " + user.Surname;
                HttpContext.Current.Session["UserSession"] = sessionUser;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
