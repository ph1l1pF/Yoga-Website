using System.Collections.Generic;
using YogaBackendAPI.Models;

namespace YogaBackendAPI.Services
{
    public interface IUsageDataService
    {
        void StoreMessage(RequestBody reqBody);
        IEnumerable<Message> GetAllMessages();

        void StoreVisit(string componentName);
        IEnumerable<Visit> GetAllVisits();
    }
}