using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMailMailAppService : IGenericApplicationService<MailMail>
    {
        Task<MailMail> CancelAsync(Guid id);
        Task<MailMail> MarkOutgoingAsync(Guid id);
        Task<MailMail> OpenDocumentAsync(Guid id);
        Task<MailMail> ProcessEmailQueueAsync(Guid id, MailMailProcessEmailQueueRequestDto input);
        Task<MailMail> RetryAsync(Guid id);
        Task<MailMail> SendAfterCommitAsync(Guid id);
        Task<MailMail> SendAsync(Guid id, MailMailSendRequestDto input);
    }
}