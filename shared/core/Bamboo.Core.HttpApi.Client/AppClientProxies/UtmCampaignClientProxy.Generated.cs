
// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;

using Bamboo.Core.Models;
using Bamboo.Core.Services;

// ReSharper disable once CheckNamespace
namespace Bamboo.Core.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IUtmCampaignAppService), typeof(UtmCampaignClientProxy))]
public partial class UtmCampaignClientProxy : ClientProxyBase<IUtmCampaignAppService>, IUtmCampaignAppService
{
    //public virtual async Task<ListResultDto<UtmCampaign>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<UtmCampaign>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<UtmCampaign>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<UtmCampaign>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<UtmCampaign> GetAsync(Guid id)
    {
        return await RequestAsync<UtmCampaign>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<UtmCampaign> CreateAsync(UtmCampaign input)
    {
        return await RequestAsync<UtmCampaign>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(UtmCampaign), input }
        });
    }

    public virtual async Task<UtmCampaign> UpdateAsync(Guid id, UtmCampaign input)
    {
        return await RequestAsync<UtmCampaign>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(UtmCampaign), input }
        });
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }
}
