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
    public interface IMailGroupAppService : IGenericAppService<MailGroup>
    {
        Task<MailGroup> CloseAsync(Guid[] ids);
        Task<MailGroup> GoToWebsiteAsync(Guid[] ids);
        Task<MailGroup> JoinAsync(Guid[] ids);
        Task<MailGroup> LeaveAsync(Guid[] ids);
        Task<MailGroup> MessageNewAsync(MailGroupMessageNewRequestDto input);
        Task<MailGroup> MessagePostAsync(MailGroupMessagePostRequestDto input);
        Task<MailGroup> MessageUpdateAsync(MailGroupMessageUpdateRequestDto input);
        Task<MailGroup> OpenAsync(Guid[] ids);
        Task<MailGroup> SendGuidelinesAsync(MailGroupSendGuidelinesRequestDto input);
    }
}