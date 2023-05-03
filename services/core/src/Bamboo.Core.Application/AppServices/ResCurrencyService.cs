
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
public partial class ResCurrencyAppService :
    CrudAppService<ResCurrency, ResCurrency, long, PagedAndSortedResultRequestDto>,
    IResCurrencyAppService
{
    private readonly IDataFilter _dataFilter;

    public ResCurrencyAppService(IDataFilter dataFilter, IRepository<ResCurrency, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
