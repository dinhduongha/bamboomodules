
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
public partial class MaintenanceStageAppService :
    CrudAppService<MaintenanceStage, MaintenanceStage, long, PagedAndSortedResultRequestDto>,
    IMaintenanceStageAppService
{
    private readonly IDataFilter _dataFilter;

    public MaintenanceStageAppService(IDataFilter dataFilter, IRepository<MaintenanceStage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
