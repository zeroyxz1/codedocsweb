using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using CodeDocsSln.Models;
using SendGrid;


namespace CodeDocsEnquries
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("enquiries")] Enquiry enquiry, TextWriter log)
        {
            Trace.TraceInformation("In ProcessQueueMessage");
            SendEmail(enquiry);
            RecordMessageInTable(enquiry);
            
        }

        private static void SendEmail(Enquiry enquiry)
        {
            Trace.TraceInformation("In the GenerateEnquiryAlert method");
            try
            {
                var myMessage = new SendGridMessage();
                myMessage.From = new System.Net.Mail.MailAddress("codedocs@codedocs.co.uk");
                myMessage.To = new System.Net.Mail.MailAddress[1] { new System.Net.Mail.MailAddress("peterworlin@hotmail.com") };
                myMessage.Subject = "New Enquiry from website " + DateTime.Now.ToShortDateString();
                StringBuilder sb = new StringBuilder();
                sb.Append("<p><b>New Enquiry</b></p>");
                sb.Append("<p>Enquiry From:" + enquiry.Name + " with email:" + enquiry.Email + "</p>");
                sb.Append("<p>Enquiry Comments:" + enquiry.Comments + "</p>");
                myMessage.Html = sb.ToString();

                Trace.TraceInformation("Setting networkcredentials");
                var username = ConfigurationManager.AppSettings["un"];
                var password = ConfigurationManager.AppSettings["pw"];
                var creds = new NetworkCredential(username, password);
                var transportWeb = new Web(creds);

                Trace.TraceInformation("Sending the mail message asynchronously and waiting.");
                var watch = Stopwatch.StartNew();
                transportWeb.DeliverAsync(myMessage).Wait();
                watch.Stop();
                Trace.TraceInformation("Completed send operation in:" + watch.ElapsedMilliseconds.ToString());

            }
            catch (Exception ex)
            {
                Trace.TraceError("Error: " + ex.ToString());
            }
        }

        private static void RecordMessageInTable(Enquiry enquiry)
        {

        }
    }
}
