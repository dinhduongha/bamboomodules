
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
public partial class MrpUnbuildAppService :
    CrudAppService<MrpUnbuild, MrpUnbuild, Guid, PagedAndSortedResultRequestDto>,
    IMrpUnbuildAppService
{
    private readonly IDataFilter _dataFilter;

    public MrpUnbuildAppService(IDataFilter dataFilter, IRepository<MrpUnbuild, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
