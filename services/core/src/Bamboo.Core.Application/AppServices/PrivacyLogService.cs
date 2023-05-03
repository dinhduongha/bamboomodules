
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
public partial class PrivacyLogAppService :
    CrudAppService<PrivacyLog, PrivacyLog, Guid, PagedAndSortedResultRequestDto>,
    IPrivacyLogAppService
{
    private readonly IDataFilter _dataFilter;

    public PrivacyLogAppService(IDataFilter dataFilter, IRepository<PrivacyLog, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
