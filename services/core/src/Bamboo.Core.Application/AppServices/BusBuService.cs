
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
public partial class BusBuAppService :
    CrudAppService<BusBu, BusBu, Guid, PagedAndSortedResultRequestDto>,
    IBusBuAppService
{
    private readonly IDataFilter _dataFilter;

    public BusBuAppService(IDataFilter dataFilter, IRepository<BusBu, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
