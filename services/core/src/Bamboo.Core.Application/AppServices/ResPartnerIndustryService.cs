
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
public partial class ResPartnerIndustryAppService :
    CrudAppService<ResPartnerIndustry, ResPartnerIndustry, long, PagedAndSortedResultRequestDto>,
    IResPartnerIndustryAppService
{
    private readonly IDataFilter _dataFilter;

    public ResPartnerIndustryAppService(IDataFilter dataFilter, IRepository<ResPartnerIndustry, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
