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
    public interface IMailTemplateAppService : IGenericApplicationService<MailTemplate>
    {
        Task<MailTemplate> CancelUnlinkAsync(Guid id);
        Task<MailTemplate> CopyDataAsync(Guid id, MailTemplateCopyDataRequestDto input);
        Task<MailTemplate> CreateActionAsync(Guid id);
        Task<MailTemplate> OpenDeleteConfirmationModalAsync(Guid id);
        Task<MailTemplate> SendMailAsync(Guid id, MailTemplateSendMailRequestDto input);
        Task<MailTemplate> SendMailBatchAsync(Guid id, MailTemplateSendMailBatchRequestDto input);
        Task<MailTemplate> UnlinkActionAsync(Guid id);
    }
}