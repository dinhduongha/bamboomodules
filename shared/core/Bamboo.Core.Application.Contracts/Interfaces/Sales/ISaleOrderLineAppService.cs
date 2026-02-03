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
        Task<SaleOrderLine> AddFromCatalogAsync(Guid[] ids);
        Task<SaleOrderLine> ComputeUomQtyAsync(SaleOrderLineComputeUomQtyRequestDto input);
        Task<SaleOrderLine> CopyDataAsync(SaleOrderLineCopyDataRequestDto input);
        Task<SaleOrderLine> GetDescriptionFollowingLinesAsync(Guid[] ids);
        Task<SaleOrderLine> GetParentSectionLineAsync(Guid[] ids);
        Task<SaleOrderLine> HasValuedMoveIdsAsync(Guid[] ids);
        Task<SaleOrderLine> ReadConvertedAsync(Guid[] ids);
    }
}