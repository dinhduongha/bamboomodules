
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
public partial class ResPartnerAppService :
    CrudAppService<ResPartner, ResPartner, Guid, PagedAndSortedResultRequestDto>,
    IResPartnerAppService
{
    private readonly IDataFilter _dataFilter;

    public ResPartnerAppService(IDataFilter dataFilter, IRepository<ResPartner, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
