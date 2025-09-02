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
    public interface IResPartnerAutocompleteSyncAppService : IGenericApplicationService<ResPartnerAutocompleteSync>
    {
        Task<ResPartnerAutocompleteSync> AddToQueueAsync(Guid id, ResPartnerAutocompleteSyncAddToQueueRequestDto input);
        Task<ResPartnerAutocompleteSync> StartSyncAsync(Guid id, ResPartnerAutocompleteSyncStartSyncRequestDto input);
    }
}