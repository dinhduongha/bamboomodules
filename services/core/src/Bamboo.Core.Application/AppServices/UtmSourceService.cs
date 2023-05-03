
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
public partial class UtmSourceAppService :
    CrudAppService<UtmSource, UtmSource, Guid, PagedAndSortedResultRequestDto>,
    IUtmSourceAppService
{
    private readonly IDataFilter _dataFilter;

    public UtmSourceAppService(IDataFilter dataFilter, IRepository<UtmSource, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
