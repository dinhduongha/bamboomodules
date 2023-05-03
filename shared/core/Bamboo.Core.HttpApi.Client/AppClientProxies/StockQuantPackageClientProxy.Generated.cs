
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
[ExposeServices(typeof(IStockQuantPackageAppService), typeof(StockQuantPackageClientProxy))]
public partial class StockQuantPackageClientProxy : ClientProxyBase<IStockQuantPackageAppService>, IStockQuantPackageAppService
{
    //public virtual async Task<ListResultDto<StockQuantPackage>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockQuantPackage>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockQuantPackage>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockQuantPackage>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockQuantPackage> GetAsync(Guid id)
    {
        return await RequestAsync<StockQuantPackage>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockQuantPackage> CreateAsync(StockQuantPackage input)
    {
        return await RequestAsync<StockQuantPackage>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockQuantPackage), input }
        });
    }

    public virtual async Task<StockQuantPackage> UpdateAsync(Guid id, StockQuantPackage input)
    {
        return await RequestAsync<StockQuantPackage>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockQuantPackage), input }
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
