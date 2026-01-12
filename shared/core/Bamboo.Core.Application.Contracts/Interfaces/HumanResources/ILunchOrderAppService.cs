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
    public interface ILunchOrderAppService : IGenericApplicationService<LunchOrder>
    {
        Task<LunchOrder> AddToCartAsync(Guid id);
        Task<LunchOrder> CancelAsync(Guid id);
        Task<LunchOrder> ConfirmAsync(Guid id);
        Task<LunchOrder> NotifyAsync(Guid id);
        Task<LunchOrder> OrderAsync(Guid id);
        Task<LunchOrder> ReorderAsync(Guid id);
        Task<LunchOrder> ResetAsync(Guid id);
        Task<LunchOrder> SendAsync(Guid id);
        Task<LunchOrder> UpdateQuantityAsync(Guid id, LunchOrderUpdateQuantityRequestDto input);
    }
}