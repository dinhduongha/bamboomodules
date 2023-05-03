
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
[ExposeServices(typeof(IIrUiViewCustomAppService), typeof(IrUiViewCustomClientProxy))]
public partial class IrUiViewCustomClientProxy : ClientProxyBase<IIrUiViewCustomAppService>, IIrUiViewCustomAppService
{
    //public virtual async Task<ListResultDto<IrUiViewCustom>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrUiViewCustom>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrUiViewCustom>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrUiViewCustom>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrUiViewCustom> GetAsync(Guid id)
    {
        return await RequestAsync<IrUiViewCustom>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrUiViewCustom> CreateAsync(IrUiViewCustom input)
    {
        return await RequestAsync<IrUiViewCustom>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrUiViewCustom), input }
        });
    }

    public virtual async Task<IrUiViewCustom> UpdateAsync(Guid id, IrUiViewCustom input)
    {
        return await RequestAsync<IrUiViewCustom>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrUiViewCustom), input }
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