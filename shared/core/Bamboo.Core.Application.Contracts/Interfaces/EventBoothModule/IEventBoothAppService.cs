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
    public interface IEventBoothAppService : IGenericApplicationService<EventBooth>
    {
        Task<EventBooth> ConfirmAsync(Guid id, EventBoothConfirmRequestDto input);
        Task<EventBooth> SetPaidAsync(Guid id);
        Task<EventBooth> ViewSaleOrderAsync(Guid id);
        Task<EventBooth> ViewSponsorAsync(Guid id);
    }
}