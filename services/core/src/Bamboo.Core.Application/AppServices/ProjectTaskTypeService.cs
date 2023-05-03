
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
public partial class ProjectTaskTypeAppService :
    CrudAppService<ProjectTaskType, ProjectTaskType, long, PagedAndSortedResultRequestDto>,
    IProjectTaskTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectTaskTypeAppService(IDataFilter dataFilter, IRepository<ProjectTaskType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
