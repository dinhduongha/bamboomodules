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
    public interface ISmsTemplateAppService : IGenericApplicationService<SmsTemplate>
    {
        Task<SmsTemplate> CopyDataAsync(Guid id, SmsTemplateCopyDataRequestDto input);
        Task<SmsTemplate> CreateSidebarActionAsync(Guid id);
        Task<SmsTemplate> UnlinkSidebarActionAsync(Guid id);
    }
}