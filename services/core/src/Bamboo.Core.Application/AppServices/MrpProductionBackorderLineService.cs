
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
public partial class MrpProductionBackorderLineAppService :
    CrudAppService<MrpProductionBackorderLine, MrpProductionBackorderLine, Guid, PagedAndSortedResultRequestDto>,
    IMrpProductionBackorderLineAppService
{
    private readonly IDataFilter _dataFilter;

    public MrpProductionBackorderLineAppService(IDataFilter dataFilter, IRepository<MrpProductionBackorderLine, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
