
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
public partial class FollowupSendingResultAppService :
    CrudAppService<FollowupSendingResult, FollowupSendingResult, Guid, PagedAndSortedResultRequestDto>,
    IFollowupSendingResultAppService
{
    private readonly IDataFilter _dataFilter;

    public FollowupSendingResultAppService(IDataFilter dataFilter, IRepository<FollowupSendingResult, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
