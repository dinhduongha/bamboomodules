
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
public partial class BaseImportTestsModelsO2mChildAppService :
    CrudAppService<BaseImportTestsModelsO2mChild, BaseImportTestsModelsO2mChild, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsO2mChildAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsO2mChildAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsO2mChild, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
