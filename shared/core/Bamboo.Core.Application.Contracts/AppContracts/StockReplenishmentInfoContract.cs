
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;

namespace Bamboo.Core.Services;
public interface IStockReplenishmentInfoAppService :
    ICrudAppService<
        StockReplenishmentInfo,
        Guid,
        PagedAndSortedResultRequestDto>
{
}
