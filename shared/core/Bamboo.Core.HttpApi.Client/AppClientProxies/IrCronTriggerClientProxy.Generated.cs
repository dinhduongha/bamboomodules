
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
[ExposeServices(typeof(IIrCronTriggerAppService), typeof(IrCronTriggerClientProxy))]
public partial class IrCronTriggerClientProxy : ClientProxyBase<IIrCronTriggerAppService>, IIrCronTriggerAppService
{
    //public virtual async Task<ListResultDto<IrCronTrigger>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrCronTrigger>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrCronTrigger>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrCronTrigger>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrCronTrigger> GetAsync(Guid id)
    {
        return await RequestAsync<IrCronTrigger>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrCronTrigger> CreateAsync(IrCronTrigger input)
    {
        return await RequestAsync<IrCronTrigger>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrCronTrigger), input }
        });
    }

    public virtual async Task<IrCronTrigger> UpdateAsync(Guid id, IrCronTrigger input)
    {
        return await RequestAsync<IrCronTrigger>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrCronTrigger), input }
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
