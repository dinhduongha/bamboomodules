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
    public interface IResPartnerAutocompleteSyncAppService : IGenericAppService<ResPartnerAutocompleteSync>
    {
        Task<ResPartnerAutocompleteSync> AddToQueueAsync(ResPartnerAutocompleteSyncAddToQueueRequestDto input);
        Task<ResPartnerAutocompleteSync> StartSyncAsync(ResPartnerAutocompleteSyncStartSyncRequestDto input);
    }
}