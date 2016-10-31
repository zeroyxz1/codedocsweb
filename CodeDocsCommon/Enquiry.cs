using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CodeDocsSln.Models
{
    public class Enquiry : TableEntity
    {
        public Enquiry() { }
        public Enquiry(string Email)
        {
            this.Email = Email;
            this.PartitionKey = this.Email;
            this.Id = Guid.NewGuid();
            
        }
        public Guid Id { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public DateTime DateActioned { get; set; }
    }
}