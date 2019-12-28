using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;

namespace Learning.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string AccountValidation { get; set; }
        public string Status { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Use Digit only")]
        [Range(01300000000, 01999999999, ErrorMessage = "Number is not 11 digit or Not valid")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Thana")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Details Location")]
        public string DetailsAddress { get; set; }
        
        public string DivName { get; set; }
        [Required]
        [Display(Name = "Division")]
        public int DivCode { get; set; }
        public string District { get; set; }
        [Required]
        [Display(Name = "District")]
        public int DisCode { get; set; }

    }
}