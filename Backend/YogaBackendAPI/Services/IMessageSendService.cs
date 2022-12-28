using YogaBackendAPI.Models;

namespace YogaBackendAPI.Services
{
    public interface IMessageSendService
    {
         void Send(RequestBody reqBody);
    }
}