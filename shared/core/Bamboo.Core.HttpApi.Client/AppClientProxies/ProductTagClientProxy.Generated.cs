
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
[ExposeServices(typeof(IProductTagAppService), typeof(ProductTagClientProxy))]
public partial class ProductTagClientProxy : ClientProxyBase<IProductTagAppService>, IProductTagAppService
{
    //public virtual async Task<ListResultDto<ProductTag>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProductTag>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProductTag>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProductTag>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProductTag> GetAsync(long id)
    {
        return await RequestAsync<ProductTag>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<ProductTag> CreateAsync(ProductTag input)
    {
        return await RequestAsync<ProductTag>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProductTag), input }
        });
    }

    public virtual async Task<ProductTag> UpdateAsync(long id, ProductTag input)
    {
        return await RequestAsync<ProductTag>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(ProductTag), input }
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
