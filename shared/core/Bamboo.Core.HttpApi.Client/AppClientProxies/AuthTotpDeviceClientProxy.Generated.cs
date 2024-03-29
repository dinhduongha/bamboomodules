
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
[ExposeServices(typeof(IAuthTotpDeviceAppService), typeof(AuthTotpDeviceClientProxy))]
public partial class AuthTotpDeviceClientProxy : ClientProxyBase<IAuthTotpDeviceAppService>, IAuthTotpDeviceAppService
{
    //public virtual async Task<ListResultDto<AuthTotpDevice>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AuthTotpDevice>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AuthTotpDevice>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AuthTotpDevice>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AuthTotpDevice> GetAsync(Guid id)
    {
        return await RequestAsync<AuthTotpDevice>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AuthTotpDevice> CreateAsync(AuthTotpDevice input)
    {
        return await RequestAsync<AuthTotpDevice>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AuthTotpDevice), input }
        });
    }

    public virtual async Task<AuthTotpDevice> UpdateAsync(Guid id, AuthTotpDevice input)
    {
        return await RequestAsync<AuthTotpDevice>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AuthTotpDevice), input }
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
