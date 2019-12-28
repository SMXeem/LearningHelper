using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Learning.Models;
using LearningHelper.Models;

namespace LearningHelper.Gateway
{
    public class PostGateway : Learning.Gateway.Gateway
    {
        public List<Category> GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            Query = "SELECT * FROM  Category";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Category aCategory = new Category();
                aCategory.ID = (int)Reader["ID"];
                aCategory.Name = Reader["Name"].ToString();
                categories.Add(aCategory);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }

        public bool AddPost(Post aPost, int aUserId)
        {
            Query = "INSERT INTO Posts(UserId,Title,CatId,Description,Fees,image,PostTime) VALUES(@UserId,@Title,@CatId,@Description,@Fees,@image,@PostTime)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("UserId", aUserId);
            Command.Parameters.AddWithValue("Title", aPost.Title);
            Command.Parameters.AddWithValue("CatId", aPost.Category);
            Command.Parameters.AddWithValue("Description", aPost.Desc);
            Command.Parameters.AddWithValue("Fees", aPost.Fees);
            Command.Parameters.AddWithValue("image", aPost.ImagePath);
            Command.Parameters.AddWithValue("PostTime", aPost.PostTime);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public List<Post> GetAllMyPost(User aUser)
        {
            List<Post> allMyPost=new List<Post>();
            Query = "SELECT posts.id,Title,Description,Fees,image,PostTime, Category.Name as CatName, TUser.Name FROM TUser,Posts,Category where Category.ID=Posts.CatId and Posts.UserId=TUser.Id and UserID = @UserID ORDER BY PostTime DESC";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("UserID", aUser.Id);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Post aPost = new Post();
                aPost.ID = (int)Reader["Id"];
                aPost.Title = Reader["Title"].ToString();
                aPost.CatName = Reader["CatName"].ToString();
                aPost.UserName = Reader["Name"].ToString();
                aPost.Fees = (float) Convert.ToDouble(Reader["Fees"]);
                aPost.Desc = Reader["Description"].ToString();
                aPost.ImagePath = Reader["image"].ToString();
                aPost.PostTime = (DateTime) Reader["PostTime"];
                allMyPost.Add(aPost);
            }
            Reader.Close();
            Connection.Close();
            return allMyPost;
        }

        public List<Post> GetSeparatePost(User aUser)
        {
            int postType;
            if (aUser.UserType == 1)
            {
                postType = 2;
            }
            else
            {
                postType = 1;
            }
            List<Post> allSeparatePosts = new List<Post>();
            Query = "SELECT posts.id,Title,Description,Fees,image,PostTime, Category.Name as CatName, TUser.Name, Thana.Name as ThanaName,District.Name as DisName FROM TUser,Posts,Category,Thana,District where Category.ID=Posts.CatId and Posts.UserId=TUser.Id and TUser.Location=Thana.Id and Thana.DistrictId=District.Id and UserType = @postType ORDER BY PostTime DESC";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("postType", postType);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Post aPost = new Post();
                aPost.ID = (int) Reader["Id"];
                aPost.Title = Reader["Title"].ToString();
                aPost.CatName = Reader["CatName"].ToString();
                aPost.UserName = Reader["Name"].ToString();
                aPost.Fees = (float)Convert.ToDouble(Reader["Fees"]);
                aPost.UserThana = Reader["ThanaName"].ToString();
                aPost.UserDis = Reader["DisName"].ToString();
                aPost.Desc = Reader["Description"].ToString();
                aPost.ImagePath = Reader["image"].ToString();
                aPost.PostTime = (DateTime)Reader["PostTime"];
                aPost.UserThana = aPost.UserThana + ", " + aPost.UserDis;
                allSeparatePosts.Add(aPost);
            }
            Reader.Close();
            Connection.Close();
            return allSeparatePosts;
        }

        public int GetTotallPost()
        {
            int Number = 0;
            Query = "SELECT count(*) AS NUM FROM  Posts";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                Number = (int)Reader["NUM"];
            }
            Reader.Close();
            Connection.Close();
            return Number;
        }

        public List<Post> GetPostByCat(int id)
        {
            List<Post> allSeparatePosts = new List<Post>();
            Query = "SELECT posts.id,Title,Description,Fees,image,PostTime, Category.Name as CatName, TUser.Name, Thana.Name as ThanaName,District.Name as DisName FROM TUser,Posts,Category,Thana,District where Category.ID=Posts.CatId and Posts.UserId=TUser.Id and TUser.Location=Thana.Id and Thana.DistrictId=District.Id and posts.CatId=@CatId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CatId", id);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Post aPost = new Post();
                aPost.ID = (int)Reader["Id"];
                aPost.Title = Reader["Title"].ToString();
                aPost.CatName = Reader["CatName"].ToString();
                aPost.UserName = Reader["Name"].ToString();
                aPost.Fees = (float)Convert.ToDouble(Reader["Fees"]);
                aPost.UserThana = Reader["ThanaName"].ToString();
                aPost.UserDis = Reader["DisName"].ToString();
                aPost.Desc = Reader["Description"].ToString();
                aPost.ImagePath = Reader["image"].ToString();
                aPost.PostTime = (DateTime)Reader["PostTime"];
                aPost.UserThana = aPost.UserThana + ", " + aPost.UserDis;
                allSeparatePosts.Add(aPost);
            }
            Reader.Close();
            Connection.Close();
            return allSeparatePosts;
        }

        public Post GetPostDetails(int id)
        {
            Query = "SELECT posts.id,Title,Description,Fees,image,PostTime, Category.Name as CatName, TUser.Name, Thana.Name as ThanaName,District.Name as DisName FROM TUser,Posts,Category,Thana,District where Category.ID=Posts.CatId and Posts.UserId=TUser.Id and TUser.Location=Thana.Id and Thana.DistrictId=District.Id and posts.id=@id";

            Post aPost = new Post();
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", id);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                aPost.ID = (int)Reader["Id"];
                aPost.Title = Reader["Title"].ToString();
                aPost.CatName = Reader["CatName"].ToString();
                aPost.UserName = Reader["Name"].ToString();
                aPost.Fees = (float)Convert.ToDouble(Reader["Fees"]);
                aPost.UserThana = Reader["ThanaName"].ToString();
                aPost.UserDis = Reader["DisName"].ToString();
                aPost.Desc = Reader["Description"].ToString();
                aPost.ImagePath = Reader["image"].ToString();
                aPost.PostTime = (DateTime)Reader["PostTime"];
                aPost.UserThana = aPost.UserThana + ", " + aPost.UserDis;
            }
            Reader.Close();
            Connection.Close();
            return aPost;
        }

        public bool AddComment(Comment aComment)
        {
            Query = "INSERT INTO Comment(UserId,PostId,Comments,Time) VALUES(@UserId,@PostId,@Comments,@Time)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("UserId", aComment.UserId);
            Command.Parameters.AddWithValue("PostId", aComment.PostId);
            Command.Parameters.AddWithValue("Comments", aComment.Comments);
            Command.Parameters.AddWithValue("Time", aComment.Time);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public List<Comment> GetPostComments(int id)
        {
            List<Comment> allComments = new List<Comment>();
            Query = "SELECT * FROM Comment,TUser where TUser.Id=Comment.UserId and Comment.PostId=@PostId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("PostId", id);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Comment aComment = new Comment();
                aComment.Id = (int)Reader["Id"];
                aComment.PostId = (int) Reader["PostId"];
                aComment.UserId = (int) Reader["UserId"];
                aComment.UName = Reader["Name"].ToString();
                aComment.Comments = Reader["Comments"].ToString();
                aComment.Time = (DateTime)Reader["Time"];
                allComments.Add(aComment);
            }
            Reader.Close();
            Connection.Close();
            return allComments;
        }
    }
}