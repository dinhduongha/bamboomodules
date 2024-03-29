
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
[ExposeServices(typeof(IProjectTagAppService), typeof(ProjectTagClientProxy))]
public partial class ProjectTagClientProxy : ClientProxyBase<IProjectTagAppService>, IProjectTagAppService
{
    //public virtual async Task<ListResultDto<ProjectTag>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProjectTag>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProjectTag>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProjectTag>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProjectTag> GetAsync(long id)
    {
        return await RequestAsync<ProjectTag>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<ProjectTag> CreateAsync(ProjectTag input)
    {
        return await RequestAsync<ProjectTag>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProjectTag), input }
        });
    }

    public virtual async Task<ProjectTag> UpdateAsync(long id, ProjectTag input)
    {
        return await RequestAsync<ProjectTag>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(ProjectTag), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
