
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
public partial class BaseImportTestsModelsCharAppService :
    CrudAppService<BaseImportTestsModelsChar, BaseImportTestsModelsChar, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsCharAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsCharAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsChar, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
