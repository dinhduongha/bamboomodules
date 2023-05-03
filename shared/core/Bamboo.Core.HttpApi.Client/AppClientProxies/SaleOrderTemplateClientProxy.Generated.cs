
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
[ExposeServices(typeof(ISaleOrderTemplateAppService), typeof(SaleOrderTemplateClientProxy))]
public partial class SaleOrderTemplateClientProxy : ClientProxyBase<ISaleOrderTemplateAppService>, ISaleOrderTemplateAppService
{
    //public virtual async Task<ListResultDto<SaleOrderTemplate>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SaleOrderTemplate>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SaleOrderTemplate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SaleOrderTemplate>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SaleOrderTemplate> GetAsync(Guid id)
    {
        return await RequestAsync<SaleOrderTemplate>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SaleOrderTemplate> CreateAsync(SaleOrderTemplate input)
    {
        return await RequestAsync<SaleOrderTemplate>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SaleOrderTemplate), input }
        });
    }

    public virtual async Task<SaleOrderTemplate> UpdateAsync(Guid id, SaleOrderTemplate input)
    {
        return await RequestAsync<SaleOrderTemplate>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SaleOrderTemplate), input }
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
