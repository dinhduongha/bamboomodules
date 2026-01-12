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
    public interface IImLivechatChannelAppService : IGenericApplicationService<ImLivechatChannel>
    {
        Task<ImLivechatChannel> GetLivechatInfoAsync(Guid id, ImLivechatChannelGetLivechatInfoRequestDto input);
        Task<ImLivechatChannel> JoinAsync(Guid id);
        Task<ImLivechatChannel> QuitAsync(Guid id);
        Task<ImLivechatChannel> ViewChatbotScriptsAsync(Guid id);
        Task<ImLivechatChannel> ViewRatingAsync(Guid id);
    }
}