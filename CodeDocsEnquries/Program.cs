using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using CodeDocsSln.Models;
using SendGrid;
using System.Net;
using System.Diagnostics;

namespace CodeDocsSln
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }

        public static void GenerateEnquiryAlert([QueueTrigger("enquiries")]Enquiry enquiry)
        {
            


        }
            
    }
}
