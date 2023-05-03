using System;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;

using Twilio.Types;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace Bamboo.LoginUiWeb.Controllers;

[Route("api/twilio")]
public class TwilioSmsController : TwilioController
{
    protected IDataSeeder _dataSeeder { get; }

    IHttpClientFactory _httpClientFactory;

    public TwilioSmsController(IHttpClientFactory httpFactory)
    {        
        _httpClientFactory = httpFactory;        
    }

    /// <summary>
    /// Callback from Twilio services
    /// </summary>
    /// <param name="incomingMessage"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("sms")]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public async Task<TwiMLResult> Index(SmsRequest incomingMessage)
    {
        var messagingResponse = new MessagingResponse();
        messagingResponse.Message(incomingMessage.Body);
        await Task.CompletedTask;
        return TwiML(messagingResponse);
    }

    [HttpPost]
    [Route("callback")]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public async Task<TwiMLResult> TwilioIncomming(SmsRequest incomingMessage)
    {
        //var rs = await _phoneService.TwilioIncomming(incomingMessage);
        //return rs;
        await Task.CompletedTask;
        return null;
    }
}
