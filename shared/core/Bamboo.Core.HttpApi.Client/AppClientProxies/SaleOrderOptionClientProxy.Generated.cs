
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
[ExposeServices(typeof(ISaleOrderOptionAppService), typeof(SaleOrderOptionClientProxy))]
public partial class SaleOrderOptionClientProxy : ClientProxyBase<ISaleOrderOptionAppService>, ISaleOrderOptionAppService
{
    //public virtual async Task<ListResultDto<SaleOrderOption>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SaleOrderOption>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SaleOrderOption>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SaleOrderOption>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SaleOrderOption> GetAsync(Guid id)
    {
        return await RequestAsync<SaleOrderOption>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SaleOrderOption> CreateAsync(SaleOrderOption input)
    {
        return await RequestAsync<SaleOrderOption>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SaleOrderOption), input }
        });
    }

    public virtual async Task<SaleOrderOption> UpdateAsync(Guid id, SaleOrderOption input)
    {
        return await RequestAsync<SaleOrderOption>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SaleOrderOption), input }
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
