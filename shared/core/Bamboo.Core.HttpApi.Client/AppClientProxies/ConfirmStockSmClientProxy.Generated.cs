
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
[ExposeServices(typeof(IConfirmStockSmAppService), typeof(ConfirmStockSmClientProxy))]
public partial class ConfirmStockSmClientProxy : ClientProxyBase<IConfirmStockSmAppService>, IConfirmStockSmAppService
{
    //public virtual async Task<ListResultDto<ConfirmStockSm>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ConfirmStockSm>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ConfirmStockSm>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ConfirmStockSm>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ConfirmStockSm> GetAsync(Guid id)
    {
        return await RequestAsync<ConfirmStockSm>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ConfirmStockSm> CreateAsync(ConfirmStockSm input)
    {
        return await RequestAsync<ConfirmStockSm>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ConfirmStockSm), input }
        });
    }

    public virtual async Task<ConfirmStockSm> UpdateAsync(Guid id, ConfirmStockSm input)
    {
        return await RequestAsync<ConfirmStockSm>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ConfirmStockSm), input }
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
