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
        Task<MailMessage> CancelLetterAsync(Guid[] ids);
        Task<MailMessage> ExportDataAsync(MailMessageExportDataRequestDto input);
        Task<MailMessage> FetchAsync(MailMessageFetchRequestDto input);
        Task<MailMessage> MarkAllAsReadAsync(MailMessageMarkAllAsReadRequestDto input);
        Task<MailMessage> OpenDocumentAsync(Guid[] ids);
        Task<MailMessage> PortalMessageFormatAsync(MailMessagePortalMessageFormatRequestDto input);
        Task<MailMessage> SendLetterAsync(Guid[] ids);
        Task<MailMessage> SetMessageDoneAsync(Guid[] ids);
        Task<MailMessage> ToggleMessageStarredAsync(Guid[] ids);
        Task<MailMessage> UnstarAllAsync(Guid[] ids);
    }
}