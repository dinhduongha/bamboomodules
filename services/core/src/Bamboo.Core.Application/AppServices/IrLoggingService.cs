
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
public partial class IrLoggingAppService :
    CrudAppService<IrLogging, IrLogging, Guid, PagedAndSortedResultRequestDto>,
    IIrLoggingAppService
{
    private readonly IDataFilter _dataFilter;

    public IrLoggingAppService(IDataFilter dataFilter, IRepository<IrLogging, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
