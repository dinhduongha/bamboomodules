
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
public partial class ResPartnerTitleAppService :
    CrudAppService<ResPartnerTitle, ResPartnerTitle, long, PagedAndSortedResultRequestDto>,
    IResPartnerTitleAppService
{
    private readonly IDataFilter _dataFilter;

    public ResPartnerTitleAppService(IDataFilter dataFilter, IRepository<ResPartnerTitle, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
