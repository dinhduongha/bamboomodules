
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
public partial class RepairTagAppService :
    CrudAppService<RepairTag, RepairTag, long, PagedAndSortedResultRequestDto>,
    IRepairTagAppService
{
    private readonly IDataFilter _dataFilter;

    public RepairTagAppService(IDataFilter dataFilter, IRepository<RepairTag, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
