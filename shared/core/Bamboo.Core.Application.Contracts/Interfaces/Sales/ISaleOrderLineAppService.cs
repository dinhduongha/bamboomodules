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
    public interface ISaleOrderLineAppService : IGenericApplicationService<SaleOrderLine>
    {
        Task<SaleOrderLine> AddFromCatalogAsync(Guid id);
        Task<SaleOrderLine> ComputeUomQtyAsync(Guid id, SaleOrderLineComputeUomQtyRequestDto input);
        Task<SaleOrderLine> CopyDataAsync(Guid id, SaleOrderLineCopyDataRequestDto input);
        Task<SaleOrderLine> GetDescriptionFollowingLinesAsync(Guid id);
        Task<SaleOrderLine> HasValuedMoveIdsAsync(Guid id);
        Task<SaleOrderLine> InitAsync(Guid id);
        Task<SaleOrderLine> ReadConvertedAsync(Guid id);
    }
}