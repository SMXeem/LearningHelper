using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning.Models;
using LearningHelper.Manager;
using LearningHelper.Models;

namespace LearningHelper.Controllers
{
    public class PostController : Controller
    {
        PostManager aPostManager=new PostManager();
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPost()
        {
            User aUserS = (User)Session["User"];
            if (aUserS == null)
                return RedirectToAction("Index", "Home");
            ViewBag.categories = aPostManager.GetAllCategory();
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(Post aPost)
        {
            User aUser = (User)Session["User"];


            aPost.ImageName = Path.GetFileNameWithoutExtension(aPost.ImageFile.FileName);
            string extension = Path.GetExtension(aPost.ImageFile.FileName);
            aPost.ImageName = aPost.ImageName + DateTime.Now.ToString("yymmssfff") + extension;
            aPost.ImagePath = "~/Image/" + aPost.ImageName;
            aPost.ImageName = Path.Combine(Server.MapPath("~/Image/"), aPost.ImageName);
            aPost.ImageFile.SaveAs(aPost.ImageName);

            aPostManager.AddPost(aPost, aUser.Id);
            
            ViewBag.categories = aPostManager.GetAllCategory();
            ModelState.Clear();
            ViewBag.Result = "Post Added";
            return View("AddedPost");
        }
        [HttpGet]
        public ActionResult AddedPost()
        {
            
            return View();
        }


        [HttpGet]
        public ActionResult ViewMyPost()
        {
            User aUser = (User)Session["User"];
            User aUserS = (User)Session["User"];
            if (aUserS == null)
                return RedirectToAction("Index", "Home");
            List<Post> aList = aPostManager.GetAllMyPost(aUser);
            if (aList==null)
            {
                ViewBag.Message = "Update Address First";
                return View(aList);
            }
            return View(aList);
        }
        [HttpGet]
        public ActionResult ViewSeparatePost()
        {
            User aUser = (User)Session["User"];
            if (aUser == null)
                return RedirectToAction("Index", "Home");
            List<Post> aList = aPostManager.GetSeparatePost(aUser);
            return View(aList);
        }
        [HttpPost]
        public ActionResult ViewSeparatePost(Post aPost)
        {
            User aUser = (User)Session["User"];
            
            List<Post> aList = aPostManager.GetSeparatePost(aUser);
            return View(aList);
        }

        [HttpPost]
        public ActionResult AddComment(Comment aComment)
        {
            aPostManager.AddComment(aComment);
            return RedirectToAction("GetPostDetails", new { id = aComment.PostId });
        }


        [HttpGet]
        public ActionResult GetPostDetails(int id)
        {
            var aPost = aPostManager.GetPostDetails(id);
            aPost.Comments = aPostManager.GetPostComments(id);
            return View(aPost);
        }
        [HttpGet]
        public ActionResult GetPostByCat(int id)
        {
            return View(aPostManager.GetPostByCat(id));
        }

    }
}