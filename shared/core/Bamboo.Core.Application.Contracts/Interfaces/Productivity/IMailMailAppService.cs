using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
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