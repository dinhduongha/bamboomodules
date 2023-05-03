
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
public partial class BaseImportTestsModelsM2oAppService :
    CrudAppService<BaseImportTestsModelsM2o, BaseImportTestsModelsM2o, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsM2oAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsM2oAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsM2o, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
