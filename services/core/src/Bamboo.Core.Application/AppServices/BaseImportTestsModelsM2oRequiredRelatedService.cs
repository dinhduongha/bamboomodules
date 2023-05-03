
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
public partial class BaseImportTestsModelsM2oRequiredRelatedAppService :
    CrudAppService<BaseImportTestsModelsM2oRequiredRelated, BaseImportTestsModelsM2oRequiredRelated, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportTestsModelsM2oRequiredRelatedAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportTestsModelsM2oRequiredRelatedAppService(IDataFilter dataFilter, IRepository<BaseImportTestsModelsM2oRequiredRelated, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
