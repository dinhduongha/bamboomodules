
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
public partial class BusPresenceAppService :
    CrudAppService<BusPresence, BusPresence, long, PagedAndSortedResultRequestDto>,
    IBusPresenceAppService
{
    private readonly IDataFilter _dataFilter;

    public BusPresenceAppService(IDataFilter dataFilter, IRepository<BusPresence, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
