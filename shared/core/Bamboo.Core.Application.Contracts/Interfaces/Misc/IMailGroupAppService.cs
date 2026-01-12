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