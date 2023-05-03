
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
[ExposeServices(typeof(IIapAccountAppService), typeof(IapAccountClientProxy))]
public partial class IapAccountClientProxy : ClientProxyBase<IIapAccountAppService>, IIapAccountAppService
{
    //public virtual async Task<ListResultDto<IapAccount>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IapAccount>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IapAccount>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IapAccount>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IapAccount> GetAsync(Guid id)
    {
        return await RequestAsync<IapAccount>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IapAccount> CreateAsync(IapAccount input)
    {
        return await RequestAsync<IapAccount>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IapAccount), input }
        });
    }

    public virtual async Task<IapAccount> UpdateAsync(Guid id, IapAccount input)
    {
        return await RequestAsync<IapAccount>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IapAccount), input }
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