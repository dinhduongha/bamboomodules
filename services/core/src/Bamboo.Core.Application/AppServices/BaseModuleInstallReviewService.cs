
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
public partial class BaseModuleInstallReviewAppService :
    CrudAppService<BaseModuleInstallReview, BaseModuleInstallReview, Guid, PagedAndSortedResultRequestDto>,
    IBaseModuleInstallReviewAppService
{
    private readonly IDataFilter _dataFilter;

    public BaseModuleInstallReviewAppService(IDataFilter dataFilter, IRepository<BaseModuleInstallReview, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
