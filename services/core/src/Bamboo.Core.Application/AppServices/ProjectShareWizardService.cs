
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
public partial class ProjectShareWizardAppService :
    CrudAppService<ProjectShareWizard, ProjectShareWizard, Guid, PagedAndSortedResultRequestDto>,
    IProjectShareWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectShareWizardAppService(IDataFilter dataFilter, IRepository<ProjectShareWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
