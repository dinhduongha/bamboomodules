
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
public partial class ProjectCollaboratorAppService :
    CrudAppService<ProjectCollaborator, ProjectCollaborator, Guid, PagedAndSortedResultRequestDto>,
    IProjectCollaboratorAppService
{
    private readonly IDataFilter _dataFilter;

    public ProjectCollaboratorAppService(IDataFilter dataFilter, IRepository<ProjectCollaborator, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
