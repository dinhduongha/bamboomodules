
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
public partial class FleetVehicleTagAppService :
    CrudAppService<FleetVehicleTag, FleetVehicleTag, long, PagedAndSortedResultRequestDto>,
    IFleetVehicleTagAppService
{
    private readonly IDataFilter _dataFilter;

    public FleetVehicleTagAppService(IDataFilter dataFilter, IRepository<FleetVehicleTag, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
