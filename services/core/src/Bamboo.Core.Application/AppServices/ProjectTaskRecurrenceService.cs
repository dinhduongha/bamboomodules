
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
public partial class ProjectTaskRecurrenceAppService :
    CrudAppService<ProjectTaskRecurrence, ProjectTaskRecurrence, Guid, PagedAndSortedResultRequestDto>,
    IProjectTaskRecurrenceAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectTaskRecurrenceAppService(IDataFilter dataFilter, IRepository<ProjectTaskRecurrence, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
