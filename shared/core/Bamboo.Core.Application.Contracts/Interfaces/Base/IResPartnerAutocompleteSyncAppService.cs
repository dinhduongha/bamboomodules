using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResPartnerAutocompleteSyncAppService : IGenericApplicationService<ResPartnerAutocompleteSync>
    {
        Task<ResPartnerAutocompleteSync> AddToQueueAsync(Guid id, ResPartnerAutocompleteSyncAddToQueueRequestDto input);
        Task<ResPartnerAutocompleteSync> StartSyncAsync(Guid id, ResPartnerAutocompleteSyncStartSyncRequestDto input);
    }
}