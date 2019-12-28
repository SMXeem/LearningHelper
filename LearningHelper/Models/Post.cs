using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningHelper.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserThana { get; set; }
        public string UserDis { get; set; }
        public string Title { get; set; }
        public int Category { get; set; }
        public string CatName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Desc { get; set; }
        [Required]
        [Display(Name = "Fees(TK)")]
        public float Fees { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime PostTime { get; set; }

        public List<Comment> Comments { get; set; }
    }
}