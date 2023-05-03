
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
[ExposeServices(typeof(IIrUiMenuAppService), typeof(IrUiMenuClientProxy))]
public partial class IrUiMenuClientProxy : ClientProxyBase<IIrUiMenuAppService>, IIrUiMenuAppService
{
    //public virtual async Task<ListResultDto<IrUiMenu>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrUiMenu>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrUiMenu>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrUiMenu>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrUiMenu> GetAsync(Guid id)
    {
        return await RequestAsync<IrUiMenu>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrUiMenu> CreateAsync(IrUiMenu input)
    {
        return await RequestAsync<IrUiMenu>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrUiMenu), input }
        });
    }

    public virtual async Task<IrUiMenu> UpdateAsync(Guid id, IrUiMenu input)
    {
        return await RequestAsync<IrUiMenu>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrUiMenu), input }
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
