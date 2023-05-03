
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Models;

namespace Bamboo.Core.Services;

//[Authorize]
public partial class RepairOrderAppService :
    CrudAppService<RepairOrder, RepairOrder, Guid, PagedAndSortedResultRequestDto>,
    IRepairOrderAppService
{
    private readonly IDataFilter _dataFilter;

    public RepairOrderAppService(IDataFilter dataFilter, IRepository<RepairOrder, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
