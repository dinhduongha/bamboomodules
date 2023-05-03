
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
public partial class HrResumeLineAppService :
    CrudAppService<HrResumeLine, HrResumeLine, Guid, PagedAndSortedResultRequestDto>,
    IHrResumeLineAppService
{
    private readonly IDataFilter _dataFilter;

    public HrResumeLineAppService(IDataFilter dataFilter, IRepository<HrResumeLine, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
