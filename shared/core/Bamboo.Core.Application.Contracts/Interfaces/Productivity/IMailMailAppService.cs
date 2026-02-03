using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMailMailAppService : IGenericAppService<MailMail>
    {
        Task<MailMail> CancelAsync(Guid[] ids);
        Task<MailMail> MarkOutgoingAsync(Guid[] ids);
        Task<MailMail> OpenDocumentAsync(Guid[] ids);
        Task<MailMail> ProcessEmailQueueAsync(MailMailProcessEmailQueueRequestDto input);
        Task<MailMail> RetryAsync(Guid[] ids);
        Task<MailMail> SendAfterCommitAsync(Guid[] ids);
        Task<MailMail> SendAndCloseAsync(Guid[] ids);
        Task<MailMail> SendAsync(MailMailSendRequestDto input);
    }
}