using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeDocsSln.Models;
using Microsoft.Azure; // Namespace for CloudConfigurationManager 
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using Newtonsoft.Json;
using System.Diagnostics;

namespace CodeDocsSln.DataAccess
{

    public class DataStore
    {
        public void Save(Enquiry enquiry)
        {
            try
            {
                Trace.TraceInformation("Entered DataAccess.Save method");
                //Parse the connection string  StorageConnectionString
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

                //Create the Queue Service Client
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

                //Get a reference to the queue - it must be lowercase!!!! else bad request 400 error
                CloudQueue queue = queueClient.GetQueueReference("enquiries");
                queue.CreateIfNotExists();

                string enq = JsonConvert.SerializeObject(enquiry);
                Trace.TraceInformation("Saving this object:" + enq);

                CloudQueueMessage msg = new CloudQueueMessage(enq);
                queue.AddMessage(msg);
                
            }
            catch(Exception ex)
            {
                Trace.TraceError("Error in saving the enquiry to the queue: " + ex.ToString());
            }
        }
    }
}
