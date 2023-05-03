
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
public partial class MaintenanceRequestAppService :
    CrudAppService<MaintenanceRequest, MaintenanceRequest, Guid, PagedAndSortedResultRequestDto>,
    IMaintenanceRequestAppService
{
    private readonly IDataFilter _dataFilter;

    public MaintenanceRequestAppService(IDataFilter dataFilter, IRepository<MaintenanceRequest, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
