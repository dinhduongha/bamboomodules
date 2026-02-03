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
    public interface IChatbotScriptAppService : IGenericApplicationService<ChatbotScript>
    {
        Task<ChatbotScript> CopyDataAsync(ChatbotScriptCopyDataRequestDto input);
        Task<ChatbotScript> TestScriptAsync(Guid[] ids);
        Task<ChatbotScript> ViewLeadsAsync(Guid[] ids);
        Task<ChatbotScript> ViewLivechatChannelsAsync(Guid[] ids);
    }
}