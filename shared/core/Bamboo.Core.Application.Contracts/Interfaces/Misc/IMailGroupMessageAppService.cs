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
    public interface IMailGroupMessageAppService : IGenericAppService<MailGroupMessage>
    {
        Task<MailGroupMessage> CopyDataAsync(MailGroupMessageCopyDataRequestDto input);
        Task<MailGroupMessage> ModerateAcceptAsync(Guid[] ids);
        Task<MailGroupMessage> ModerateAllowAsync(Guid[] ids);
        Task<MailGroupMessage> ModerateBanAsync(Guid[] ids);
        Task<MailGroupMessage> ModerateBanWithCommentAsync(MailGroupMessageModerateBanWithCommentRequestDto input);
        Task<MailGroupMessage> ModerateRejectAsync(Guid[] ids);
        Task<MailGroupMessage> ModerateRejectWithCommentAsync(MailGroupMessageModerateRejectWithCommentRequestDto input);
    }
}