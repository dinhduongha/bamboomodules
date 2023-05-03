
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
public partial class BaseImportImportAppService :
    CrudAppService<BaseImportImport, BaseImportImport, Guid, PagedAndSortedResultRequestDto>,
    IBaseImportImportAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseImportImportAppService(IDataFilter dataFilter, IRepository<BaseImportImport, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
