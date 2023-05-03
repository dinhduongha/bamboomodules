
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
public partial class UtmTagAppService :
    CrudAppService<UtmTag, UtmTag, long, PagedAndSortedResultRequestDto>,
    IUtmTagAppService
{
    private readonly IDataFilter _dataFilter;

    public UtmTagAppService(IDataFilter dataFilter, IRepository<UtmTag, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
