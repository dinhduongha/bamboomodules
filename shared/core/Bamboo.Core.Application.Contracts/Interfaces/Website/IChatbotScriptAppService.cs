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
        Task<ChatbotScript> CopyDataAsync(Guid id, ChatbotScriptCopyDataRequestDto input);
        Task<ChatbotScript> TestScriptAsync(Guid id);
        Task<ChatbotScript> ViewLeadsAsync(Guid id);
        Task<ChatbotScript> ViewLivechatChannelsAsync(Guid id);
    }
}