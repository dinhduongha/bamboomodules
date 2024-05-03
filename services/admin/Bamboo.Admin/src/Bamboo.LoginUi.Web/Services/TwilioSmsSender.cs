using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


using Volo.Abp.DependencyInjection;
using Volo.Abp.Sms;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace Bamboo.Abp.LoginUi.Web;

public class TwilioSmsSender : ISmsSender, ITransientDependency
{
    IConfiguration _configuration;
    public TwilioSmsSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(SmsMessage smsMessage)
    {
        // Send sms to client
        var from = _configuration["Twilio:AccountPhone"];
        var msid = _configuration["Twilio:MessagingServiceSid"];
        var messageOptions = new CreateMessageOptions(new PhoneNumber(smsMessage.PhoneNumber));
        messageOptions.MessagingServiceSid = msid;
        messageOptions.Body = $"{smsMessage.Text}";

        //var message = MessageResource.Create(messageOptions);

        await Task.CompletedTask;

    }
}