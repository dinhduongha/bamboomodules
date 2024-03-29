
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
[ExposeServices(typeof(IProjectProjectAppService), typeof(ProjectProjectClientProxy))]
public partial class ProjectProjectClientProxy : ClientProxyBase<IProjectProjectAppService>, IProjectProjectAppService
{
    //public virtual async Task<ListResultDto<ProjectProject>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProjectProject>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProjectProject>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProjectProject>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProjectProject> GetAsync(Guid id)
    {
        return await RequestAsync<ProjectProject>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ProjectProject> CreateAsync(ProjectProject input)
    {
        return await RequestAsync<ProjectProject>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProjectProject), input }
        });
    }

    public virtual async Task<ProjectProject> UpdateAsync(Guid id, ProjectProject input)
    {
        return await RequestAsync<ProjectProject>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ProjectProject), input }
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
