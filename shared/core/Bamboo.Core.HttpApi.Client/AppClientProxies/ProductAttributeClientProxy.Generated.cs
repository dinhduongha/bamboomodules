
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
[ExposeServices(typeof(IProductAttributeAppService), typeof(ProductAttributeClientProxy))]
public partial class ProductAttributeClientProxy : ClientProxyBase<IProductAttributeAppService>, IProductAttributeAppService
{
    //public virtual async Task<ListResultDto<ProductAttribute>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProductAttribute>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProductAttribute>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProductAttribute>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProductAttribute> GetAsync(long id)
    {
        return await RequestAsync<ProductAttribute>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<ProductAttribute> CreateAsync(ProductAttribute input)
    {
        return await RequestAsync<ProductAttribute>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProductAttribute), input }
        });
    }

    public virtual async Task<ProductAttribute> UpdateAsync(long id, ProductAttribute input)
    {
        return await RequestAsync<ProductAttribute>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(ProductAttribute), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
