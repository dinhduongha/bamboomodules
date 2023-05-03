
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
public partial class UtmStageAppService :
    CrudAppService<UtmStage, UtmStage, long, PagedAndSortedResultRequestDto>,
    IUtmStageAppService
{
    private readonly IDataFilter _dataFilter;

    public UtmStageAppService(IDataFilter dataFilter, IRepository<UtmStage, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
