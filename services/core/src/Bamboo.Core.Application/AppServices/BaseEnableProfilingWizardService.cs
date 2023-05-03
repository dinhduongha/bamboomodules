
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
public partial class BaseEnableProfilingWizardAppService :
    CrudAppService<BaseEnableProfilingWizard, BaseEnableProfilingWizard, Guid, PagedAndSortedResultRequestDto>,
    IBaseEnableProfilingWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseEnableProfilingWizardAppService(IDataFilter dataFilter, IRepository<BaseEnableProfilingWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
