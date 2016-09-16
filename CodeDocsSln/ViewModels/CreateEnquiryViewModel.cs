using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeDocsSln.ViewModels
{
    public class CreateEnquiryViewModel
    {
        [Required(ErrorMessage = "Name is required - otherwise what would I call you?")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email is required - else I wont be able to reply")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage="You need to tell me something...lol")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
}