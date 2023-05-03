
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
[ExposeServices(typeof(IWebsiteRobotAppService), typeof(WebsiteRobotClientProxy))]
public partial class WebsiteRobotClientProxy : ClientProxyBase<IWebsiteRobotAppService>, IWebsiteRobotAppService
{
    //public virtual async Task<ListResultDto<WebsiteRobot>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<WebsiteRobot>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<WebsiteRobot>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<WebsiteRobot>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<WebsiteRobot> GetAsync(Guid id)
    {
        return await RequestAsync<WebsiteRobot>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<WebsiteRobot> CreateAsync(WebsiteRobot input)
    {
        return await RequestAsync<WebsiteRobot>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(WebsiteRobot), input }
        });
    }

    public virtual async Task<WebsiteRobot> UpdateAsync(Guid id, WebsiteRobot input)
    {
        return await RequestAsync<WebsiteRobot>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(WebsiteRobot), input }
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
