
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
public partial class WebsiteConfiguratorFeatureAppService :
    CrudAppService<WebsiteConfiguratorFeature, WebsiteConfiguratorFeature, Guid, PagedAndSortedResultRequestDto>,
    IWebsiteConfiguratorFeatureAppService
{
    private readonly IDataFilter _dataFilter;

    public WebsiteConfiguratorFeatureAppService(IDataFilter dataFilter, IRepository<WebsiteConfiguratorFeature, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
