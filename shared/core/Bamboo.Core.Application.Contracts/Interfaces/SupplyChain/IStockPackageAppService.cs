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
    public interface IStockPackageAppService : IGenericApplicationService<StockPackage>
    {
        Task<StockPackage> AddToPickingAsync(Guid[] ids);
        Task<StockPackage> PutInPackAsync(Guid[] ids);
        Task<StockPackage> RemovePackageAsync(Guid[] ids);
        Task<StockPackage> UnpackAsync(Guid[] ids);
        Task<StockPackage> ViewPickingAsync(Guid[] ids);
    }
}