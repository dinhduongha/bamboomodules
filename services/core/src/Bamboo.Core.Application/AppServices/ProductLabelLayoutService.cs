
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
public partial class ProductLabelLayoutAppService :
    CrudAppService<ProductLabelLayout, ProductLabelLayout, Guid, PagedAndSortedResultRequestDto>,
    IProductLabelLayoutAppService
{
    private readonly IDataFilter _dataFilter;

    public ProductLabelLayoutAppService(IDataFilter dataFilter, IRepository<ProductLabelLayout, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
