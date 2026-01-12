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
    public interface IMailMessageAppService : IGenericApplicationService<MailMessage>
    {
        Task<MailMessage> CancelLetterAsync(Guid id);
        Task<MailMessage> ExportDataAsync(Guid id, MailMessageExportDataRequestDto input);
        Task<MailMessage> FetchAsync(Guid id, MailMessageFetchRequestDto input);
        Task<MailMessage> InitAsync(Guid id);
        Task<MailMessage> IsThreadMessageAsync(Guid id, MailMessageIsThreadMessageRequestDto input);
        Task<MailMessage> MarkAllAsReadAsync(Guid id, MailMessageMarkAllAsReadRequestDto input);
        Task<MailMessage> OpenDocumentAsync(Guid id);
        Task<MailMessage> PortalMessageFormatAsync(Guid id, MailMessagePortalMessageFormatRequestDto input);
        Task<MailMessage> SendLetterAsync(Guid id);
        Task<MailMessage> SetMessageDoneAsync(Guid id);
        Task<MailMessage> ToggleMessageStarredAsync(Guid id);
        Task<MailMessage> UnstarAllAsync(Guid id);
    }
}