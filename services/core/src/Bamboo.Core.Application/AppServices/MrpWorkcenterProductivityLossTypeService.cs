
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
public partial class MrpWorkcenterProductivityLossTypeAppService :
    CrudAppService<MrpWorkcenterProductivityLossType, MrpWorkcenterProductivityLossType, long, PagedAndSortedResultRequestDto>,
    IMrpWorkcenterProductivityLossTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public MrpWorkcenterProductivityLossTypeAppService(IDataFilter dataFilter, IRepository<MrpWorkcenterProductivityLossType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
