
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
[ExposeServices(typeof(IProductSupplierinfoAppService), typeof(ProductSupplierinfoClientProxy))]
public partial class ProductSupplierinfoClientProxy : ClientProxyBase<IProductSupplierinfoAppService>, IProductSupplierinfoAppService
{
    //public virtual async Task<ListResultDto<ProductSupplierinfo>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ProductSupplierinfo>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ProductSupplierinfo>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ProductSupplierinfo>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ProductSupplierinfo> GetAsync(Guid id)
    {
        return await RequestAsync<ProductSupplierinfo>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ProductSupplierinfo> CreateAsync(ProductSupplierinfo input)
    {
        return await RequestAsync<ProductSupplierinfo>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ProductSupplierinfo), input }
        });
    }

    public virtual async Task<ProductSupplierinfo> UpdateAsync(Guid id, ProductSupplierinfo input)
    {
        return await RequestAsync<ProductSupplierinfo>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ProductSupplierinfo), input }
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