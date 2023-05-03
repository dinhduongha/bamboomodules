
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
public partial class PortalWizardUserAppService :
    CrudAppService<PortalWizardUser, PortalWizardUser, Guid, PagedAndSortedResultRequestDto>,
    IPortalWizardUserAppService
{
    private readonly IDataFilter _dataFilter;

    public PortalWizardUserAppService(IDataFilter dataFilter, IRepository<PortalWizardUser, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
