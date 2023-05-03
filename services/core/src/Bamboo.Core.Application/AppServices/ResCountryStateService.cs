
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
public partial class ResCountryStateAppService :
    CrudAppService<ResCountryState, ResCountryState, long, PagedAndSortedResultRequestDto>,
    IResCountryStateAppService
{
    private readonly IDataFilter _dataFilter;

    public ResCountryStateAppService(IDataFilter dataFilter, IRepository<ResCountryState, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
