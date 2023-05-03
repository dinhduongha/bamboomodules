
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
public partial class MrpProductionSplitMultiAppService :
    CrudAppService<MrpProductionSplitMulti, MrpProductionSplitMulti, Guid, PagedAndSortedResultRequestDto>,
    IMrpProductionSplitMultiAppService
{
    private readonly IDataFilter _dataFilter;

    public MrpProductionSplitMultiAppService(IDataFilter dataFilter, IRepository<MrpProductionSplitMulti, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
