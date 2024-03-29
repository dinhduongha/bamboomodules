
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
[ExposeServices(typeof(IMaintenanceStageAppService), typeof(MaintenanceStageClientProxy))]
public partial class MaintenanceStageClientProxy : ClientProxyBase<IMaintenanceStageAppService>, IMaintenanceStageAppService
{
    //public virtual async Task<ListResultDto<MaintenanceStage>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MaintenanceStage>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MaintenanceStage>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MaintenanceStage>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MaintenanceStage> GetAsync(long id)
    {
        return await RequestAsync<MaintenanceStage>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<MaintenanceStage> CreateAsync(MaintenanceStage input)
    {
        return await RequestAsync<MaintenanceStage>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MaintenanceStage), input }
        });
    }

    public virtual async Task<MaintenanceStage> UpdateAsync(long id, MaintenanceStage input)
    {
        return await RequestAsync<MaintenanceStage>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(MaintenanceStage), input }
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
