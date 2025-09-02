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
    public interface IMailGroupAppService : IGenericApplicationService<MailGroup>
    {
        Task<MailGroup> GoToWebsiteAsync(Guid id);
        Task<MailGroup> JoinAsync(Guid id);
        Task<MailGroup> LeaveAsync(Guid id);
        Task<MailGroup> MessageNewAsync(Guid id, MailGroupMessageNewRequestDto input);
        Task<MailGroup> MessagePostAsync(Guid id, MailGroupMessagePostRequestDto input);
        Task<MailGroup> MessageUpdateAsync(Guid id, MailGroupMessageUpdateRequestDto input);
        Task<MailGroup> SendGuidelinesAsync(Guid id, MailGroupSendGuidelinesRequestDto input);
    }
}