
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
public partial class PosCategoryAppService :
    CrudAppService<PosCategory, PosCategory, long, PagedAndSortedResultRequestDto>,
    IPosCategoryAppService
{
    private readonly IDataFilter _dataFilter;

    public PosCategoryAppService(IDataFilter dataFilter, IRepository<PosCategory, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
