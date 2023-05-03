
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
public partial class BaseImportTestsModelsO2mAppService :
    CrudAppService<BaseImportTestsModelsO2m, BaseImportTestsModelsO2m, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsO2mAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsO2mAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsO2m, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
