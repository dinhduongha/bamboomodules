
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
public partial class HrRecruitmentDegreeAppService :
    CrudAppService<HrRecruitmentDegree, HrRecruitmentDegree, long, PagedAndSortedResultRequestDto>,
    IHrRecruitmentDegreeAppService
{
    private readonly IDataFilter _dataFilter;

    public HrRecruitmentDegreeAppService(IDataFilter dataFilter, IRepository<HrRecruitmentDegree, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
