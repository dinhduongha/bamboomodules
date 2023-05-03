
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
public partial class HrSkillTypeAppService :
    CrudAppService<HrSkillType, HrSkillType, long, PagedAndSortedResultRequestDto>,
    IHrSkillTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public HrSkillTypeAppService(IDataFilter dataFilter, IRepository<HrSkillType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
