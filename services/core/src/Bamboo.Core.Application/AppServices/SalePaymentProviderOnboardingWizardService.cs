
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
public partial class SalePaymentProviderOnboardingWizardAppService :
    CrudAppService<SalePaymentProviderOnboardingWizard, SalePaymentProviderOnboardingWizard, Guid, PagedAndSortedResultRequestDto>,
    ISalePaymentProviderOnboardingWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public SalePaymentProviderOnboardingWizardAppService(IDataFilter dataFilter, IRepository<SalePaymentProviderOnboardingWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
