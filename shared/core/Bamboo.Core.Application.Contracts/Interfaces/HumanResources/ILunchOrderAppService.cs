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
    public interface ILunchOrderAppService : IGenericAppService<LunchOrder>
    {
        Task<LunchOrder> AddToCartAsync(Guid[] ids);
        Task<LunchOrder> CancelAsync(Guid[] ids);
        Task<LunchOrder> ConfirmAsync(Guid[] ids);
        Task<LunchOrder> NotifyAsync(Guid[] ids);
        Task<LunchOrder> OrderAsync(Guid[] ids);
        Task<LunchOrder> ReorderAsync(Guid[] ids);
        Task<LunchOrder> ResetAsync(Guid[] ids);
        Task<LunchOrder> SendAsync(Guid[] ids);
        Task<LunchOrder> UpdateQuantityAsync(LunchOrderUpdateQuantityRequestDto input);
    }
}