
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
public partial class IrModelAccessAppService :
    CrudAppService<IrModelAccess, IrModelAccess, Guid, PagedAndSortedResultRequestDto>,
    IIrModelAccessAppService
{
    private readonly IDataFilter _dataFilter;

    public IrModelAccessAppService(IDataFilter dataFilter, IRepository<IrModelAccess, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
