
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
public partial class BaseImportTestsModelsM2oRelatedAppService :
    CrudAppService<BaseImportTestsModelsM2oRelated, BaseImportTestsModelsM2oRelated, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsM2oRelatedAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsM2oRelatedAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsM2oRelated, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
