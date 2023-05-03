
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
public partial class BaseImportTestsModelsCharRequiredAppService :
    CrudAppService<BaseImportTestsModelsCharRequired, BaseImportTestsModelsCharRequired, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsCharRequiredAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsCharRequiredAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsCharRequired, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
