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
    public interface ILunchOrderAppService : IGenericApplicationService<LunchOrder>
    {
        Task<LunchOrder> AddToCartAsync(Guid id);
        Task<LunchOrder> CancelAsync(Guid id);
        Task<LunchOrder> ConfirmAsync(Guid id);
        Task<LunchOrder> InitAsync(Guid id);
        Task<LunchOrder> NotifyAsync(Guid id);
        Task<LunchOrder> OrderAsync(Guid id);
        Task<LunchOrder> ReorderAsync(Guid id);
        Task<LunchOrder> ResetAsync(Guid id);
        Task<LunchOrder> SendAsync(Guid id);
        Task<LunchOrder> UpdateQuantityAsync(Guid id, LunchOrderUpdateQuantityRequestDto input);
    }
}