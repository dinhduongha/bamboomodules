
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
public partial class BaseImportTestsModelsCharReadonlyAppService :
    CrudAppService<BaseImportTestsModelsCharReadonly, BaseImportTestsModelsCharReadonly, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsCharReadonlyAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsCharReadonlyAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsCharReadonly, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
