
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
public partial class BaseImportTestsModelsM2oRequiredAppService :
    CrudAppService<BaseImportTestsModelsM2oRequired, BaseImportTestsModelsM2oRequired, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsM2oRequiredAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsM2oRequiredAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsM2oRequired, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
