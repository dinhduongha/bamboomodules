
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
[ExposeServices(typeof(IIrModelAccessAppService), typeof(IrModelAccessClientProxy))]
public partial class IrModelAccessClientProxy : ClientProxyBase<IIrModelAccessAppService>, IIrModelAccessAppService
{
    //public virtual async Task<ListResultDto<IrModelAccess>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrModelAccess>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrModelAccess>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrModelAccess>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrModelAccess> GetAsync(Guid id)
    {
        return await RequestAsync<IrModelAccess>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrModelAccess> CreateAsync(IrModelAccess input)
    {
        return await RequestAsync<IrModelAccess>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrModelAccess), input }
        });
    }

    public virtual async Task<IrModelAccess> UpdateAsync(Guid id, IrModelAccess input)
    {
        return await RequestAsync<IrModelAccess>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrModelAccess), input }
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
