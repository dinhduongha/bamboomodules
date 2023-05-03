
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
[ExposeServices(typeof(IIrActServerAppService), typeof(IrActServerClientProxy))]
public partial class IrActServerClientProxy : ClientProxyBase<IIrActServerAppService>, IIrActServerAppService
{
    //public virtual async Task<ListResultDto<IrActServer>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrActServer>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrActServer>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrActServer>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrActServer> GetAsync(Guid id)
    {
        return await RequestAsync<IrActServer>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrActServer> CreateAsync(IrActServer input)
    {
        return await RequestAsync<IrActServer>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrActServer), input }
        });
    }

    public virtual async Task<IrActServer> UpdateAsync(Guid id, IrActServer input)
    {
        return await RequestAsync<IrActServer>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrActServer), input }
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
