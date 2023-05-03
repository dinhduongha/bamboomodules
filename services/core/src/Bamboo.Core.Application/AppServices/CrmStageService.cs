
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
public partial class CrmStageAppService :
    CrudAppService<CrmStage, CrmStage, long, PagedAndSortedResultRequestDto>,
    ICrmStageAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmStageAppService(IDataFilter dataFilter, IRepository<CrmStage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
