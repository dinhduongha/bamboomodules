
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
public partial class CrmLead2opportunityPartnerAppService :
    CrudAppService<CrmLead2opportunityPartner, CrmLead2opportunityPartner, Guid, PagedAndSortedResultRequestDto>,
    ICrmLead2opportunityPartnerAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmLead2opportunityPartnerAppService(IDataFilter dataFilter, IRepository<CrmLead2opportunityPartner, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
