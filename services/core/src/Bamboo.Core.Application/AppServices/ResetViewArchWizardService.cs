
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
public partial class ResetViewArchWizardAppService :
    CrudAppService<ResetViewArchWizard, ResetViewArchWizard, Guid, PagedAndSortedResultRequestDto>,
    IResetViewArchWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public ResetViewArchWizardAppService(IDataFilter dataFilter, IRepository<ResetViewArchWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
