using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeDocsSln.Models
{
    public class Enquiry
    {
        public Guid Id { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public DateTime DateActioned { get; set; }
    }
}