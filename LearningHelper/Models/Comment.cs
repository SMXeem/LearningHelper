using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningHelper.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UName { get; set; }
        public int PostId { get; set; }
        public string Comments { get; set; }
        public DateTime Time { get; set; }
    }
}