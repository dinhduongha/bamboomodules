
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
public partial class HrJobAppService :
    CrudAppService<HrJob, HrJob, Guid, PagedAndSortedResultRequestDto>,
    IHrJobAppService
{
    private readonly IDataFilter _dataFilter;

    public HrJobAppService(IDataFilter dataFilter, IRepository<HrJob, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
