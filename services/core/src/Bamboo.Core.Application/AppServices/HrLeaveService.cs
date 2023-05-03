
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
public partial class HrLeaveAppService :
    CrudAppService<HrLeave, HrLeave, Guid, PagedAndSortedResultRequestDto>,
    IHrLeaveAppService
{
    private readonly IDataFilter _dataFilter;

    public HrLeaveAppService(IDataFilter dataFilter, IRepository<HrLeave, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
