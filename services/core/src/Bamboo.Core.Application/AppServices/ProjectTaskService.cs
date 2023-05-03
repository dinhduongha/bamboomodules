
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
public partial class ProjectTaskAppService :
    CrudAppService<ProjectTask, ProjectTask, Guid, PagedAndSortedResultRequestDto>,
    IProjectTaskAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectTaskAppService(IDataFilter dataFilter, IRepository<ProjectTask, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
