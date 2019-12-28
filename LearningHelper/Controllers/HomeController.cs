using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningHelper.Manager;
using LearningHelper.Models;

namespace LearningHelper.Controllers
{
    public class HomeController : Controller
    {
        private UserManager aUserManager = new UserManager();
        PostManager aPostManager=new PostManager();
        public ActionResult Index()
        {

            ViewBag.Learner = aUserManager.GetTotallLearner(1);
            ViewBag.Trainer = aUserManager.GetTotallLearner(2);
            ViewBag.Post = aPostManager.GetTotallPost();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learning Helper description page.";

            return View();
        }

        public static List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            PostManager aPostManager=new PostManager();
            categories=aPostManager.GetAllCategory();
            return categories;
        } 

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}