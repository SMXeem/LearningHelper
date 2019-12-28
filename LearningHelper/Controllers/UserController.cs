using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Learning.Models;
using LearningHelper.Manager;
using LearningHelper.Models;

namespace LearningHelper.Controllers
{
    public class UserController : Controller
    {
        UserManager aUserManager = new UserManager();
        //User Registration
        public ActionResult CreateUser()
        {
            User aUser = (User)Session["User"];
            if (aUser != null)
                return RedirectToAction("Index", "Home");
            ViewBag.Divs = aUserManager.GetAllDiv();

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User aUser)
        {

            ViewBag.Divs = aUserManager.GetAllDiv();
            aUser.Email = aUser.Email.ToLower();
            if (aUserManager.CreateUser(aUser)==0)
            {
                @ViewBag.Result = "Email already exits.";
                return View();
            }
            Session["User"] = aUser;
            return View("ConfirmMail");
        }
        //User Login
        public ActionResult LoginUser()
        {
            User aUserS = (User)Session["User"];
            if (aUserS  != null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(User aUser)
        {
            aUser.Email = aUser.Email.ToLower();
            aUser =aUserManager.LoginUser(aUser);
            if (aUser==null)
            {
                User aaUser=new User();
                aaUser.AccountValidation = "Wrong Email Or Password";
                return View("LoginUser", aaUser);
            }
            Session["User"] = aUser;
            return RedirectToAction("Index", "Home");
        }
        //Log Out
        public ActionResult LogOutUser()
        {
            User aUserS = (User)Session["User"];
            if (aUserS == null)
                return RedirectToAction("Index", "Home");
            Session["User"] = null;
            return View("LogOutUserMessage");
        }
        public ActionResult LogOutUserMessage()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmMail(SendOTPMail aSendOtpMail)
        {
            User aUser=new User();
            aUser = (User)Session["User"];

            aUser.Status = aSendOtpMail.OTPCode;
            
            if (aUserManager.ConfirmOTP(aUser)=="1")
            {
                return RedirectToAction("Index", "Home");
            }

            @ViewBag.Result = "OTP Code not Match";
            return View();
        }
        public ActionResult UpdateUser()
        {
            User aUser= (User)Session["User"];
            User aUserS = (User)Session["User"];
            if (aUserS == null)
                return RedirectToAction("Index", "Home");
            ViewBag.Divs = aUserManager.GetAllDiv();
            return View(aUser);
        }
        [HttpPost]
        public ActionResult UpdateUser(User aUser)
        {
            aUser.Email = aUser.Email.ToLower();
            ViewBag.Divs = aUserManager.GetAllDiv();
            Session["User"] = aUser;
            aUserManager.UpdateUserDetails(aUser);
            return View("UpdateUserSuccessful");
        }
        public ActionResult UpdateUserSuccessful()
        {
            
            return View();
        }

        public JsonResult DistrictDetails(string DivCode)
        {
            var districts = aUserManager.GetAllDistrict(DivCode);
            return Json(districts);
        }
        public JsonResult ThanaDetails(string DisCode)
        {
            var thanas = aUserManager.GetAllThana(DisCode);
            return Json(thanas);
        }
    }
}