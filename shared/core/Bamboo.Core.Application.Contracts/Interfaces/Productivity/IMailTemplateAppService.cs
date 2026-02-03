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
    public interface IMailTemplateAppService : IGenericAppService<MailTemplate>
    {
        Task<MailTemplate> CopyDataAsync(MailTemplateCopyDataRequestDto input);
        Task<MailTemplate> CreateActionAsync(Guid[] ids);
        Task<MailTemplate> OpenMailPreviewAsync(Guid[] ids);
        Task<MailTemplate> SendMailAsync(MailTemplateSendMailRequestDto input);
        Task<MailTemplate> SendMailBatchAsync(MailTemplateSendMailBatchRequestDto input);
        Task<MailTemplate> UnlinkActionAsync(Guid[] ids);
    }
}