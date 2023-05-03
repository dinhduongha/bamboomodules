
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
public partial class ChangeProductionQtyAppService :
    CrudAppService<ChangeProductionQty, ChangeProductionQty, Guid, PagedAndSortedResultRequestDto>,
    IChangeProductionQtyAppService
{
    private readonly IDataFilter _dataFilter;

    public ChangeProductionQtyAppService(IDataFilter dataFilter, IRepository<ChangeProductionQty, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
