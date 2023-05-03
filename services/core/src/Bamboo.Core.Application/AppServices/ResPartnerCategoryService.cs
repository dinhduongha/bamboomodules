
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
public partial class ResPartnerCategoryAppService :
    CrudAppService<ResPartnerCategory, ResPartnerCategory, long, PagedAndSortedResultRequestDto>,
    IResPartnerCategoryAppService
{
    private readonly IDataFilter _dataFilter;

    public ResPartnerCategoryAppService(IDataFilter dataFilter, IRepository<ResPartnerCategory, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
