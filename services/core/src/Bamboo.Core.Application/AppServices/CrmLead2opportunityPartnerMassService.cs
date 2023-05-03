
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
public partial class CrmLead2opportunityPartnerMassAppService :
    CrudAppService<CrmLead2opportunityPartnerMass, CrmLead2opportunityPartnerMass, Guid, PagedAndSortedResultRequestDto>,
    ICrmLead2opportunityPartnerMassAppService
{
    private readonly IDataFilter _dataFilter;

    public CrmLead2opportunityPartnerMassAppService(IDataFilter dataFilter, IRepository<CrmLead2opportunityPartnerMass, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
