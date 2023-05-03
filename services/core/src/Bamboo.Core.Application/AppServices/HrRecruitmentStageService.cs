
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
public partial class HrRecruitmentStageAppService :
    CrudAppService<HrRecruitmentStage, HrRecruitmentStage, long, PagedAndSortedResultRequestDto>,
    IHrRecruitmentStageAppService
{
    private readonly IDataFilter _dataFilter;

    public HrRecruitmentStageAppService(IDataFilter dataFilter, IRepository<HrRecruitmentStage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
