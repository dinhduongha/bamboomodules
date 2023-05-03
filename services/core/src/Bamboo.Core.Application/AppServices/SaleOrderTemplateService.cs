
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
public partial class SaleOrderTemplateAppService :
    CrudAppService<SaleOrderTemplate, SaleOrderTemplate, Guid, PagedAndSortedResultRequestDto>,
    ISaleOrderTemplateAppService
{
    private readonly IDataFilter _dataFilter;

    public SaleOrderTemplateAppService(IDataFilter dataFilter, IRepository<SaleOrderTemplate, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
