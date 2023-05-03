
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
public partial class HrDepartureReasonAppService :
    CrudAppService<HrDepartureReason, HrDepartureReason, long, PagedAndSortedResultRequestDto>,
    IHrDepartureReasonAppService
{
    private readonly IDataFilter _dataFilter;

    public HrDepartureReasonAppService(IDataFilter dataFilter, IRepository<HrDepartureReason, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
