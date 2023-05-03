
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
public partial class FleetVehicleStateAppService :
    CrudAppService<FleetVehicleState, FleetVehicleState, long, PagedAndSortedResultRequestDto>,
    IFleetVehicleStateAppService
{
    private readonly IDataFilter _dataFilter;

    public FleetVehicleStateAppService(IDataFilter dataFilter, IRepository<FleetVehicleState, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
