using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningHelper.Models
{
    public class SendOTPMail
    {
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Message { get; set; }
        [Required]
        [Display(Name = "OTP Code")]
        public string OTPCode { get; set; }
    }
}