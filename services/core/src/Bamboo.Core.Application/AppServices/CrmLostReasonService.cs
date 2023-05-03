
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
public partial class CrmLostReasonAppService :
    CrudAppService<CrmLostReason, CrmLostReason, long, PagedAndSortedResultRequestDto>,
    ICrmLostReasonAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmLostReasonAppService(IDataFilter dataFilter, IRepository<CrmLostReason, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
