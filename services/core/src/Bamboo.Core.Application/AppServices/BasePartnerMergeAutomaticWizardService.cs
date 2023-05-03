
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
public partial class BasePartnerMergeAutomaticWizardAppService :
    CrudAppService<BasePartnerMergeAutomaticWizard, BasePartnerMergeAutomaticWizard, Guid, PagedAndSortedResultRequestDto>,
    IBasePartnerMergeAutomaticWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public BasePartnerMergeAutomaticWizardAppService(IDataFilter dataFilter, IRepository<BasePartnerMergeAutomaticWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
