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
    public interface IImLivechatChannelAppService : IGenericAppService<ImLivechatChannel>
    {
        Task<ImLivechatChannel> GetLivechatInfoAsync(ImLivechatChannelGetLivechatInfoRequestDto input);
        Task<ImLivechatChannel> JoinAsync(Guid[] ids);
        Task<ImLivechatChannel> QuitAsync(Guid[] ids);
        Task<ImLivechatChannel> ViewChatbotScriptsAsync(Guid[] ids);
        Task<ImLivechatChannel> ViewRatingAsync(Guid[] ids);
        Task<List<Dictionary<string, object>>> WebReadAsync(ImLivechatChannelWebReadRequestDto input);
    }
}