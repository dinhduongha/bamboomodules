
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
public partial class ProjectTaskTypeDeleteWizardAppService :
    CrudAppService<ProjectTaskTypeDeleteWizard, ProjectTaskTypeDeleteWizard, Guid, PagedAndSortedResultRequestDto>,
    IProjectTaskTypeDeleteWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectTaskTypeDeleteWizardAppService(IDataFilter dataFilter, IRepository<ProjectTaskTypeDeleteWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
