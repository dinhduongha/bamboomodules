using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrMailServerController
    {
        
        [HttpPost]
        [Route("{id}/action-retrieve-max-email-size")]
        public async Task<IActionResult> ActionRetrieveMaxEmailSizeAsync(Guid id)
        {
            var result = await _appService.RetrieveMaxEmailSizeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/build-email")]
        public async Task<IActionResult> BuildEmailAsync(Guid id, [FromBody] IrMailServerBuildEmailRequestDto input)
        {
            var result = await _appService.BuildEmailAsync(id, input.EmailFrom, input.EmailTo, input.Subject, input.Body, input.EmailCc, input.EmailBcc, input.ReplyTo, input.Attachments, input.MessageId, input.References, input.ObjectId, input.Subtype, input.Headers, input.BodyAlternative, input.SubtypeAlternative);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/connect")]
        public async Task<IActionResult> ConnectAsync(Guid id, [FromBody] IrMailServerConnectRequestDto input)
        {
            var result = await _appService.ConnectAsync(id, input.Host, input.Port, input.User, input.Password, input.Encryption, input.SmtpFrom, input.SslCertificate, input.SslPrivateKey, input.SmtpDebug, input.MailServerId, input.AllowArchived);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-email")]
        public async Task<IActionResult> SendEmailAsync(Guid id, [FromBody] IrMailServerSendEmailRequestDto input)
        {
            var result = await _appService.SendEmailAsync(id, input.Message, input.MailServerId, input.SmtpServer, input.SmtpPort, input.SmtpUser, input.SmtpPassword, input.SmtpEncryption, input.SmtpSslCertificate, input.SmtpSslPrivateKey, input.SmtpDebug, input.SmtpSession);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/test-smtp-connection")]
        public async Task<IActionResult> TestSmtpConnectionAsync(Guid id, [FromBody] IrMailServerTestSmtpConnectionRequestDto input)
        {
            var result = await _appService.TestSmtpConnectionAsync(id, input.AutodetectMaxEmailSize);
            return Ok(result);
        }
    }
}