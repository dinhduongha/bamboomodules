
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
[ExposeServices(typeof(IProductRibbonAppService), typeof(ProductRibbonClientProxy))]
public partial class ProductRibbonClientProxy : ClientProxyBase<IProductRibbonAppService>, IProductRibbonAppService
{
    //public virtual async Task<ListResultDto<ProductRibbon>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProductRibbon>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProductRibbon>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProductRibbon>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProductRibbon> GetAsync(Guid id)
    {
        return await RequestAsync<ProductRibbon>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ProductRibbon> CreateAsync(ProductRibbon input)
    {
        return await RequestAsync<ProductRibbon>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProductRibbon), input }
        });
    }

    public virtual async Task<ProductRibbon> UpdateAsync(Guid id, ProductRibbon input)
    {
        return await RequestAsync<ProductRibbon>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ProductRibbon), input }
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
