
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
public partial class IrModelDatumAppService :
    CrudAppService<IrModelDatum, IrModelDatum, Guid, PagedAndSortedResultRequestDto>,
    IIrModelDatumAppService
{
    private readonly IDataFilter _dataFilter;

    public IrModelDatumAppService(IDataFilter dataFilter, IRepository<IrModelDatum, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
