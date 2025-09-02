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