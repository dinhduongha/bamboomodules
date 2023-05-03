
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
public partial class RepairLineAppService :
    CrudAppService<RepairLine, RepairLine, Guid, PagedAndSortedResultRequestDto>,
    IRepairLineAppService
{
    private readonly IDataFilter _dataFilter;

    public RepairLineAppService(IDataFilter dataFilter, IRepository<RepairLine, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
