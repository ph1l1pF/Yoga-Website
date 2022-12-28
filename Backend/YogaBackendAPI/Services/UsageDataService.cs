
using MongoDB.Driver;
using YogaBackendAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace YogaBackendAPI.Services
{
    public class UsageDataService : IUsageDataService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMongoCollection<Visit> _visitCollection;

        public UsageDataService(IYogaDatabaseSettings yogaDatabaseSettings, IWebHostEnvironment env)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MongoConnectionString"));
            var database = client.GetDatabase(yogaDatabaseSettings.DatabaseName);

            if (env.EnvironmentName == "Development") {
                _messageCollection = database.GetCollection<Message>(yogaDatabaseSettings.MessagesCollectionNameTest);
                _visitCollection = database.GetCollection<Visit>(yogaDatabaseSettings.VisitsCollectionNameTest);
            } 
            else {
                _messageCollection = database.GetCollection<Message>(yogaDatabaseSettings.MessagesCollectionName);
                _visitCollection = database.GetCollection<Visit>(yogaDatabaseSettings.VisitsCollectionName);
            }

        }
        
        public IEnumerable<Message> GetAllMessages()
        {
            return _messageCollection.Find(x => true).ToList();
        }

        public IEnumerable<Visit> GetAllVisits()
        {
            return _visitCollection.Find(_ => true).ToList();
        }

        public void StoreMessage(RequestBody reqBody)
        {
            try
            {
                _messageCollection.InsertOne(new Message
                {
                    Text = reqBody.Message,
                    MailCustomer = reqBody.MailCustomer,
                    NameCustomer = reqBody.NameCustomer,
                    Date = DateTime.Now
                });
            }
            catch (MongoException)
            {
                
            }
        }

        public void StoreVisit(string componentName)
        {
            try
            {
                _visitCollection.InsertOne(new Visit
                {
                    Date = DateTime.Now,
                    ComponentName = componentName
                });
            }
            catch (MongoException)
            {
                
            }
        }
    }
}