
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
public partial class PosSessionAppService :
    CrudAppService<PosSession, PosSession, Guid, PagedAndSortedResultRequestDto>,
    IPosSessionAppService
{
    private readonly IDataFilter _dataFilter;

    public PosSessionAppService(IDataFilter dataFilter, IRepository<PosSession, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
