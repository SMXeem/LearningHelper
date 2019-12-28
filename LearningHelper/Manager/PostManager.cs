using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Learning.Models;
using LearningHelper.Gateway;
using LearningHelper.Models;

namespace LearningHelper.Manager
{
    public class PostManager
    {
        PostGateway aPostGateway=new PostGateway();


        public List<Category> GetAllCategory()
        {
            return aPostGateway.GetAllCategory();
        }

        public bool AddPost(Post aPost, int aUserId)
        {
            
            aPost.PostTime=DateTime.Now;
            return aPostGateway.AddPost(aPost,aUserId);
        }

        public List<Post> GetAllMyPost(User aUser)
        {
            return aPostGateway.GetAllMyPost(aUser);
        }

        public List<Post> GetSeparatePost(User aUser)
        {
            return aPostGateway.GetSeparatePost(aUser);
        }

        public int GetTotallPost()
        {
            return aPostGateway.GetTotallPost();
        }

        public List<Post> GetPostByCat(int id)
        {
            return aPostGateway.GetPostByCat(id);
        }

        public Post GetPostDetails(int id)
        {
            return aPostGateway.GetPostDetails(id);
        }

        public bool AddComment(Comment aComment)
        {
            aComment.Time = DateTime.Now;
            return aPostGateway.AddComment(aComment);
        }

        public List<Comment> GetPostComments(int id)
        {
            return aPostGateway.GetPostComments(id);
        }
    }
}