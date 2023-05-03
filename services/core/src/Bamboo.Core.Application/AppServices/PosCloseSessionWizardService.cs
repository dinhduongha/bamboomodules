
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
public partial class PosCloseSessionWizardAppService :
    CrudAppService<PosCloseSessionWizard, PosCloseSessionWizard, Guid, PagedAndSortedResultRequestDto>,
    IPosCloseSessionWizardAppService
{
    private readonly IDataFilter _dataFilter;

    public PosCloseSessionWizardAppService(IDataFilter dataFilter, IRepository<PosCloseSessionWizard, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
