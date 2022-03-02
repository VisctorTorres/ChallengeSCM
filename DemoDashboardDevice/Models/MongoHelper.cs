using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace DemoDashboardDevice.Models
{
    public class MongoHelper
    {
        public static IMongoClient client{get; set;}
        public static IMongoDatabase database {get; set;}
        public static string MongoConnection = "mongodb+srv://UserData:PassData@challenge.bloaa.mongodb.net/Challenge?retryWrites=true&w=majority";
        public static string MongoDatabase = "Challenge";

        internal static void ConnectToMongoService()
        {
            try{
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }

}