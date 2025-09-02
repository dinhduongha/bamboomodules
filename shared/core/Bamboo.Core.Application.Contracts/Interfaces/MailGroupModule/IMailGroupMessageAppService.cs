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
    public interface IMailGroupMessageAppService : IGenericApplicationService<MailGroupMessage>
    {
        Task<MailGroupMessage> CopyDataAsync(Guid id, MailGroupMessageCopyDataRequestDto input);
        Task<MailGroupMessage> ModerateAcceptAsync(Guid id);
        Task<MailGroupMessage> ModerateAllowAsync(Guid id);
        Task<MailGroupMessage> ModerateBanAsync(Guid id);
        Task<MailGroupMessage> ModerateBanWithCommentAsync(Guid id, MailGroupMessageModerateBanWithCommentRequestDto input);
        Task<MailGroupMessage> ModerateRejectAsync(Guid id);
        Task<MailGroupMessage> ModerateRejectWithCommentAsync(Guid id, MailGroupMessageModerateRejectWithCommentRequestDto input);
    }
}