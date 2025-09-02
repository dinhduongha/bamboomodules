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
    public interface IChatbotScriptAppService : IGenericApplicationService<ChatbotScript>
    {
        Task<ChatbotScript> CopyDataAsync(Guid id, ChatbotScriptCopyDataRequestDto input);
        Task<ChatbotScript> TestScriptAsync(Guid id);
        Task<ChatbotScript> ViewLeadsAsync(Guid id);
        Task<ChatbotScript> ViewLivechatChannelsAsync(Guid id);
    }
}