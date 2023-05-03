
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
[ExposeServices(typeof(IIrDefaultAppService), typeof(IrDefaultClientProxy))]
public partial class IrDefaultClientProxy : ClientProxyBase<IIrDefaultAppService>, IIrDefaultAppService
{
    //public virtual async Task<ListResultDto<IrDefault>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<IrDefault>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<IrDefault>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<IrDefault>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<IrDefault> GetAsync(Guid id)
    {
        return await RequestAsync<IrDefault>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<IrDefault> CreateAsync(IrDefault input)
    {
        return await RequestAsync<IrDefault>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(IrDefault), input }
        });
    }

    public virtual async Task<IrDefault> UpdateAsync(Guid id, IrDefault input)
    {
        return await RequestAsync<IrDefault>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(IrDefault), input }
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