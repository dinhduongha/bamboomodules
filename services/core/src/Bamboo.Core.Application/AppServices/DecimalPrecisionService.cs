
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
public partial class DecimalPrecisionAppService :
    CrudAppService<DecimalPrecision, DecimalPrecision, long, PagedAndSortedResultRequestDto>,
    IDecimalPrecisionAppService
{
    private readonly IDataFilter _dataFilter;

    public DecimalPrecisionAppService(IDataFilter dataFilter, IRepository<DecimalPrecision, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
