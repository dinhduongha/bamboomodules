
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
public partial class PosOrderAppService :
    CrudAppService<PosOrder, PosOrder, Guid, PagedAndSortedResultRequestDto>,
    IPosOrderAppService
{
    private readonly IDataFilter _dataFilter;

    public PosOrderAppService(IDataFilter dataFilter, IRepository<PosOrder, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
