
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
[ExposeServices(typeof(IIrFilterAppService), typeof(IrFilterClientProxy))]
public partial class IrFilterClientProxy : ClientProxyBase<IIrFilterAppService>, IIrFilterAppService
{
    //public virtual async Task<ListResultDto<IrFilter>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrFilter>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrFilter>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrFilter>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrFilter> GetAsync(Guid id)
    {
        return await RequestAsync<IrFilter>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrFilter> CreateAsync(IrFilter input)
    {
        return await RequestAsync<IrFilter>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrFilter), input }
        });
    }

    public virtual async Task<IrFilter> UpdateAsync(Guid id, IrFilter input)
    {
        return await RequestAsync<IrFilter>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrFilter), input }
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
