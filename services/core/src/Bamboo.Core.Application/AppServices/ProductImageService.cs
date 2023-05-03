
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
public partial class ProductImageAppService :
    CrudAppService<ProductImage, ProductImage, Guid, PagedAndSortedResultRequestDto>,
    IProductImageAppService
{
    private readonly IDataFilter _dataFilter;

    public ProductImageAppService(IDataFilter dataFilter, IRepository<ProductImage, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
