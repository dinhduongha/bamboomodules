
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
public partial class PortalWizardAppService :
    CrudAppService<PortalWizard, PortalWizard, Guid, PagedAndSortedResultRequestDto>,
    IPortalWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public PortalWizardAppService(IDataFilter dataFilter, IRepository<PortalWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
