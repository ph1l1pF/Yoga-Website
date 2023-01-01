using Microsoft.AspNetCore.Mvc;
using YogaBackendAPI.Models;
using YogaBackendAPI.Services;

namespace YogaBackendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{

    private readonly IUsageDataService _messageStorageService;
    private readonly IMessageSendService _messageSendService;

    public MailController(IUsageDataService messageStorageService, IMessageSendService messageSendService)
    {
        _messageStorageService = messageStorageService;
        _messageSendService = messageSendService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("sendmail")]
    public IActionResult SendMail([FromBody] RequestBody reqBody)
    {
        try
        {
            if(!ParametersAreValid(reqBody))
            {
                return BadRequest("Invalid parameters.");
            }
            _messageSendService.Send(reqBody);
            _messageStorageService.StoreMessage(reqBody);
        }
        catch (Exception e) 
        {
            Console.WriteLine("Fehler: " + e);
                
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        return new OkObjectResult("Mail successfully sent.");
    }

    private static bool ParametersAreValid(RequestBody requestBody)
    {
        return requestBody != null &&
               !string.IsNullOrWhiteSpace(requestBody.MailCustomer) && 
               !string.IsNullOrWhiteSpace(requestBody.NameCustomer) &&
               !string.IsNullOrWhiteSpace(requestBody.Message);
    }
}