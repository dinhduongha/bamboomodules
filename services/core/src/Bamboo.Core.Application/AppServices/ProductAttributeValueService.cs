
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
public partial class ProductAttributeValueAppService :
    CrudAppService<ProductAttributeValue, ProductAttributeValue, Guid, PagedAndSortedResultRequestDto>,
    IProductAttributeValueAppService
{
    private readonly IDataFilter _dataFilter;

    public ProductAttributeValueAppService(IDataFilter dataFilter, IRepository<ProductAttributeValue, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
