
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
public partial class ProductReplenishAppService :
    CrudAppService<ProductReplenish, ProductReplenish, Guid, PagedAndSortedResultRequestDto>,
    IProductReplenishAppService
{
    private readonly IDataFilter _dataFilter;

    public ProductReplenishAppService(IDataFilter dataFilter, IRepository<ProductReplenish, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
