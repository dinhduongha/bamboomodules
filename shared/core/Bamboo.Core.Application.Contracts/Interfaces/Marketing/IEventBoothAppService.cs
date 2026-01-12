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
    public interface IEventBoothAppService : IGenericApplicationService<EventBooth>
    {
        Task<EventBooth> ConfirmAsync(Guid id, EventBoothConfirmRequestDto input);
        Task<EventBooth> SetPaidAsync(Guid id);
        Task<EventBooth> ViewSaleOrderAsync(Guid id);
        Task<EventBooth> ViewSponsorAsync(Guid id);
    }
}