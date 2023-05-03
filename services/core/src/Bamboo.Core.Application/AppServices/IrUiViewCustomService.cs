
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
public partial class IrUiViewCustomAppService :
    CrudAppService<IrUiViewCustom, IrUiViewCustom, Guid, PagedAndSortedResultRequestDto>,
    IIrUiViewCustomAppService
{
    private readonly IDataFilter _dataFilter;

    public IrUiViewCustomAppService(IDataFilter dataFilter, IRepository<IrUiViewCustom, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
