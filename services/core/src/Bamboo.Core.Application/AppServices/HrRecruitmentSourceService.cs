
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
public partial class HrRecruitmentSourceAppService :
    CrudAppService<HrRecruitmentSource, HrRecruitmentSource, Guid, PagedAndSortedResultRequestDto>,
    IHrRecruitmentSourceAppService
{
    private readonly IDataFilter _dataFilter;

    public HrRecruitmentSourceAppService(IDataFilter dataFilter, IRepository<HrRecruitmentSource, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
