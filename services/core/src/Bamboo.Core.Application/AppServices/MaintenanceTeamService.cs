
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
public partial class MaintenanceTeamAppService :
    CrudAppService<MaintenanceTeam, MaintenanceTeam, Guid, PagedAndSortedResultRequestDto>,
    IMaintenanceTeamAppService
{
    private readonly IDataFilter _dataFilter;

    public MaintenanceTeamAppService(IDataFilter dataFilter, IRepository<MaintenanceTeam, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
