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
        Task<StockPackage> AddToPickingAsync(Guid id);
        Task<StockPackage> PutInPackAsync(Guid id);
        Task<StockPackage> RemovePackageAsync(Guid id);
        Task<StockPackage> UnpackAsync(Guid id);
        Task<StockPackage> ViewPickingAsync(Guid id);
    }
}