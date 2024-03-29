
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
[ExposeServices(typeof(IIrMailServerAppService), typeof(IrMailServerClientProxy))]
public partial class IrMailServerClientProxy : ClientProxyBase<IIrMailServerAppService>, IIrMailServerAppService
{
    //public virtual async Task<ListResultDto<IrMailServer>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrMailServer>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrMailServer>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrMailServer>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrMailServer> GetAsync(Guid id)
    {
        return await RequestAsync<IrMailServer>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrMailServer> CreateAsync(IrMailServer input)
    {
        return await RequestAsync<IrMailServer>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrMailServer), input }
        });
    }

    public virtual async Task<IrMailServer> UpdateAsync(Guid id, IrMailServer input)
    {
        return await RequestAsync<IrMailServer>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrMailServer), input }
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
