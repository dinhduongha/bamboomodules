
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
[ExposeServices(typeof(IAccountUnreconcileAppService), typeof(AccountUnreconcileClientProxy))]
public partial class AccountUnreconcileClientProxy : ClientProxyBase<IAccountUnreconcileAppService>, IAccountUnreconcileAppService
{
    //public virtual async Task<ListResultDto<AccountUnreconcile>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountUnreconcile>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountUnreconcile>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountUnreconcile>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountUnreconcile> GetAsync(Guid id)
    {
        return await RequestAsync<AccountUnreconcile>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountUnreconcile> CreateAsync(AccountUnreconcile input)
    {
        return await RequestAsync<AccountUnreconcile>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountUnreconcile), input }
        });
    }

    public virtual async Task<AccountUnreconcile> UpdateAsync(Guid id, AccountUnreconcile input)
    {
        return await RequestAsync<AccountUnreconcile>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountUnreconcile), input }
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