
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
public partial class ProductCategoryAppService :
    CrudAppService<ProductCategory, ProductCategory, long, PagedAndSortedResultRequestDto>,
    IProductCategoryAppService
{
    private readonly IDataFilter _dataFilter;

    public ProductCategoryAppService(IDataFilter dataFilter, IRepository<ProductCategory, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
