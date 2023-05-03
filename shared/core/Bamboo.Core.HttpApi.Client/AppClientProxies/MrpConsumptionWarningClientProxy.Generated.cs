
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
[ExposeServices(typeof(IMrpConsumptionWarningAppService), typeof(MrpConsumptionWarningClientProxy))]
public partial class MrpConsumptionWarningClientProxy : ClientProxyBase<IMrpConsumptionWarningAppService>, IMrpConsumptionWarningAppService
{
    //public virtual async Task<ListResultDto<MrpConsumptionWarning>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpConsumptionWarning>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpConsumptionWarning>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpConsumptionWarning>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpConsumptionWarning> GetAsync(Guid id)
    {
        return await RequestAsync<MrpConsumptionWarning>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpConsumptionWarning> CreateAsync(MrpConsumptionWarning input)
    {
        return await RequestAsync<MrpConsumptionWarning>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpConsumptionWarning), input }
        });
    }

    public virtual async Task<MrpConsumptionWarning> UpdateAsync(Guid id, MrpConsumptionWarning input)
    {
        return await RequestAsync<MrpConsumptionWarning>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpConsumptionWarning), input }
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