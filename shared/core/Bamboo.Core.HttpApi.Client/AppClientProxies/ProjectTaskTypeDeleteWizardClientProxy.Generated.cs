
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
[ExposeServices(typeof(IProjectTaskTypeDeleteWizardAppService), typeof(ProjectTaskTypeDeleteWizardClientProxy))]
public partial class ProjectTaskTypeDeleteWizardClientProxy : ClientProxyBase<IProjectTaskTypeDeleteWizardAppService>, IProjectTaskTypeDeleteWizardAppService
{
    //public virtual async Task<ListResultDto<ProjectTaskTypeDeleteWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProjectTaskTypeDeleteWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProjectTaskTypeDeleteWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProjectTaskTypeDeleteWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProjectTaskTypeDeleteWizard> GetAsync(Guid id)
    {
        return await RequestAsync<ProjectTaskTypeDeleteWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ProjectTaskTypeDeleteWizard> CreateAsync(ProjectTaskTypeDeleteWizard input)
    {
        return await RequestAsync<ProjectTaskTypeDeleteWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProjectTaskTypeDeleteWizard), input }
        });
    }

    public virtual async Task<ProjectTaskTypeDeleteWizard> UpdateAsync(Guid id, ProjectTaskTypeDeleteWizard input)
    {
        return await RequestAsync<ProjectTaskTypeDeleteWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ProjectTaskTypeDeleteWizard), input }
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
