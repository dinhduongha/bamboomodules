
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
public partial class ProjectProjectStageAppService :
    CrudAppService<ProjectProjectStage, ProjectProjectStage, long, PagedAndSortedResultRequestDto>,
    IProjectProjectStageAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectProjectStageAppService(IDataFilter dataFilter, IRepository<ProjectProjectStage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
